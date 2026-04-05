using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class ReservationQueueService : IReservationQueueService
{
    private readonly IBookReservationRepository _reservationRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly INotificationRepository _notificationRepository;
    private readonly IBookLoanRepository _loanRepository;
    private readonly IFineRepository _fineRepository;

    public ReservationQueueService(
        IBookReservationRepository reservationRepository,
        IBookRepository bookRepository,
        ICustomerRepository customerRepository,
        INotificationRepository notificationRepository,
        IBookLoanRepository loanRepository,
        IFineRepository fineRepository)
    {
        _reservationRepository = reservationRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
        _notificationRepository = notificationRepository;
        _loanRepository = loanRepository;
        _fineRepository = fineRepository;
    }

    public int GetMembershipPriority(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 1,
            MembershipType.Senior => 2,
            MembershipType.Student => 3,
            MembershipType.Standard => 4,
            MembershipType.Basic => 5,
            _ => 5
        };
    }

    public int GetMaxActiveReservations(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 5,
            MembershipType.Senior => 4,
            MembershipType.Student => 4,
            MembershipType.Standard => 3,
            MembershipType.Basic => 1,
            _ => 1
        };
    }

    public int GetReservationExpiryDays(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 7,
            MembershipType.Senior => 5,
            MembershipType.Student => 5,
            MembershipType.Standard => 3,
            MembershipType.Basic => 2,
            _ => 2
        };
    }

    public async Task<BookReservationDto> CreatePrioritizedReservationAsync(CreateBookReservationDto createDto)
    {
        var book = await _bookRepository.GetByIdAsync(createDto.BookId)
            ?? throw new NotFoundException(nameof(Book), createDto.BookId);

        var customer = await _customerRepository.GetByIdAsync(createDto.CustomerId)
            ?? throw new NotFoundException(nameof(Customer), createDto.CustomerId);

        if (!customer.IsActive)
            throw new BadRequestException("Customer membership is not active.");

        if (customer.MembershipExpiryDate.HasValue && customer.MembershipExpiryDate.Value < DateTime.UtcNow)
            throw new BadRequestException("Customer membership has expired.");

        // Check outstanding fines
        var outstandingFines = await _fineRepository.GetTotalUnpaidFinesByCustomerAsync(customer.Id);
        if (outstandingFines > 0)
            throw new BadRequestException(
                $"Customer has unpaid fines ({outstandingFines:C}). Please settle fines before making reservations.");

        // Check max active reservations per membership
        var customerReservations = await _reservationRepository.GetByCustomerIdAsync(createDto.CustomerId);
        var activeReservationCount = customerReservations.Count(r =>
            r.Status == ReservationStatus.Pending || r.Status == ReservationStatus.Confirmed);
        var maxReservations = GetMaxActiveReservations(customer.MembershipType);

        if (activeReservationCount >= maxReservations)
            throw new BadRequestException(
                $"Maximum active reservation limit ({maxReservations}) reached for {customer.MembershipType} membership.");

        // Check duplicate reservation for same book
        var hasDuplicate = customerReservations.Any(r =>
            r.BookId == createDto.BookId &&
            (r.Status == ReservationStatus.Pending || r.Status == ReservationStatus.Confirmed));
        if (hasDuplicate)
            throw new ConflictException("Customer already has an active reservation for this book.");

        // Check if customer currently has the book on loan
        var customerLoans = await _loanRepository.GetByCustomerIdAsync(createDto.CustomerId);
        var hasActiveLoan = customerLoans.Any(l =>
            l.BookId == createDto.BookId &&
            (l.Status == LoanStatus.Active || l.Status == LoanStatus.Overdue));
        if (hasActiveLoan)
            throw new BadRequestException("Customer already has this book on active loan. Return it before reserving.");

        // Calculate priority-based queue position
        var existingReservations = await _reservationRepository.GetByBookIdAsync(createDto.BookId);
        var pendingReservations = existingReservations
            .Where(r => r.Status == ReservationStatus.Pending)
            .ToList();

        var customerPriority = GetMembershipPriority(customer.MembershipType);
        var expiryDays = GetReservationExpiryDays(customer.MembershipType);

        var reservation = new BookReservation
        {
            Id = Guid.NewGuid(),
            BookId = createDto.BookId,
            CustomerId = createDto.CustomerId,
            ReservationDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddDays(expiryDays),
            Status = ReservationStatus.Pending,
            Notes = createDto.Notes,
            CreatedAt = DateTime.UtcNow
        };

        // Find insertion point based on priority
        var queuePosition = 1;
        foreach (var existing in pendingReservations.OrderBy(r => r.QueuePosition))
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(existing.CustomerId);
            if (existingCustomer is null) continue;

            var existingPriority = GetMembershipPriority(existingCustomer.MembershipType);
            if (customerPriority < existingPriority)
                break;

            queuePosition = existing.QueuePosition + 1;
        }

        reservation.QueuePosition = queuePosition;

        // Shift lower-priority reservations down
        var toShift = pendingReservations
            .Where(r => r.QueuePosition >= queuePosition)
            .OrderByDescending(r => r.QueuePosition);

        foreach (var r in toShift)
        {
            r.QueuePosition++;
            r.UpdatedAt = DateTime.UtcNow;
            await _reservationRepository.UpdateAsync(r);
        }

        await _reservationRepository.AddAsync(reservation);

        // If book is available, auto-confirm the first in queue
        if (book.AvailableCopies > 0 && queuePosition == 1)
        {
            reservation.Status = ReservationStatus.Confirmed;
            reservation.UpdatedAt = DateTime.UtcNow;
            await _reservationRepository.UpdateAsync(reservation);

            await SendNotificationAsync(
                customer.Id,
                "Reservation Confirmed",
                $"Your reservation for '{book.Title}' has been confirmed. Please pick up the book within {expiryDays} days.",
                NotificationType.ReservationReady);
        }

        return reservation.ToDto();
    }

    public async Task<IEnumerable<BookReservationDto>> GetQueueByBookAsync(Guid bookId)
    {
        if (!await _bookRepository.ExistsAsync(bookId))
            throw new NotFoundException(nameof(Book), bookId);

        var reservations = await _reservationRepository.GetByBookIdAsync(bookId);
        return reservations
            .Where(r => r.Status == ReservationStatus.Pending || r.Status == ReservationStatus.Confirmed)
            .OrderBy(r => r.QueuePosition)
            .Select(r => r.ToDto());
    }

    public async Task<ReservationQueueStatusDto> GetQueueStatusAsync(Guid bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId)
            ?? throw new NotFoundException(nameof(Book), bookId);

        var reservations = await _reservationRepository.GetByBookIdAsync(bookId);
        var activeReservations = reservations
            .Where(r => r.Status == ReservationStatus.Pending || r.Status == ReservationStatus.Confirmed)
            .OrderBy(r => r.QueuePosition)
            .ToList();

        var queueEntries = new List<ReservationQueueEntryDto>();
        foreach (var reservation in activeReservations)
        {
            var customer = await _customerRepository.GetByIdAsync(reservation.CustomerId);
            queueEntries.Add(new ReservationQueueEntryDto
            {
                ReservationId = reservation.Id,
                CustomerId = reservation.CustomerId,
                CustomerName = customer is not null ? $"{customer.FirstName} {customer.LastName}" : "Unknown",
                MembershipType = customer?.MembershipType.ToString() ?? "Unknown",
                Priority = customer is not null ? GetMembershipPriority(customer.MembershipType) : 5,
                QueuePosition = reservation.QueuePosition,
                ReservationDate = reservation.ReservationDate,
                ExpiryDate = reservation.ExpiryDate,
                Status = reservation.Status
            });
        }

        // Estimate wait: average loan period (14 days) * (queue size / total copies)
        var estimatedWaitDays = book.TotalCopies > 0
            ? (int)Math.Ceiling(14.0 * activeReservations.Count / book.TotalCopies)
            : activeReservations.Count * 14;

        return new ReservationQueueStatusDto
        {
            BookId = bookId,
            BookTitle = book.Title,
            TotalInQueue = activeReservations.Count,
            AvailableCopies = book.AvailableCopies,
            TotalCopies = book.TotalCopies,
            EstimatedWaitDays = estimatedWaitDays,
            QueueEntries = queueEntries
        };
    }

    public async Task CancelAndRequeueAsync(Guid reservationId)
    {
        var reservation = await _reservationRepository.GetByIdAsync(reservationId)
            ?? throw new NotFoundException(nameof(BookReservation), reservationId);

        if (reservation.Status != ReservationStatus.Pending && reservation.Status != ReservationStatus.Confirmed)
            throw new BadRequestException("Only pending or confirmed reservations can be cancelled.");

        var cancelledPosition = reservation.QueuePosition;
        var bookId = reservation.BookId;

        reservation.Status = ReservationStatus.Cancelled;
        reservation.UpdatedAt = DateTime.UtcNow;
        await _reservationRepository.UpdateAsync(reservation);

        // Requeue: shift everyone after the cancelled position up by one
        var allReservations = await _reservationRepository.GetByBookIdAsync(bookId);
        var toShift = allReservations
            .Where(r => r.QueuePosition > cancelledPosition &&
                        (r.Status == ReservationStatus.Pending || r.Status == ReservationStatus.Confirmed))
            .OrderBy(r => r.QueuePosition);

        foreach (var r in toShift)
        {
            r.QueuePosition--;
            r.UpdatedAt = DateTime.UtcNow;
            await _reservationRepository.UpdateAsync(r);
        }

        // If the cancelled was confirmed (position 1), promote the next one
        if (cancelledPosition == 1)
        {
            await PromoteNextInQueueAsync(bookId);
        }

        // Notify the customer
        var customer = await _customerRepository.GetByIdAsync(reservation.CustomerId);
        if (customer is not null)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            await SendNotificationAsync(
                customer.Id,
                "Reservation Cancelled",
                $"Your reservation for '{book?.Title ?? "Unknown"}' has been cancelled.",
                NotificationType.General);
        }
    }

    public async Task<int> ProcessExpiredReservationsAsync()
    {
        var expiredReservations = await _reservationRepository.GetExpiredReservationsAsync();
        var processedCount = 0;

        var bookIdsToPromote = new HashSet<Guid>();

        foreach (var reservation in expiredReservations)
        {
            if (reservation.Status != ReservationStatus.Pending && reservation.Status != ReservationStatus.Confirmed)
                continue;

            var wasFirstInQueue = reservation.QueuePosition == 1;
            reservation.Status = ReservationStatus.Expired;
            reservation.UpdatedAt = DateTime.UtcNow;
            await _reservationRepository.UpdateAsync(reservation);

            // Requeue remaining
            var allReservations = await _reservationRepository.GetByBookIdAsync(reservation.BookId);
            var toShift = allReservations
                .Where(r => r.Id != reservation.Id &&
                            r.QueuePosition > reservation.QueuePosition &&
                            (r.Status == ReservationStatus.Pending || r.Status == ReservationStatus.Confirmed))
                .OrderBy(r => r.QueuePosition);

            foreach (var r in toShift)
            {
                r.QueuePosition--;
                r.UpdatedAt = DateTime.UtcNow;
                await _reservationRepository.UpdateAsync(r);
            }

            // Notify customer about expiry
            await SendNotificationAsync(
                reservation.CustomerId,
                "Reservation Expired",
                $"Your reservation (Queue #{reservation.QueuePosition}) has expired. Please create a new reservation if needed.",
                NotificationType.ReservationExpired);

            if (wasFirstInQueue)
                bookIdsToPromote.Add(reservation.BookId);

            processedCount++;
        }

        // Promote next in queue for books where the first reservation expired
        foreach (var bookId in bookIdsToPromote)
        {
            await PromoteNextInQueueAsync(bookId);
        }

        return processedCount;
    }

    public async Task<BookReservationDto?> PromoteNextInQueueAsync(Guid bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);
        if (book is null || book.AvailableCopies <= 0)
            return null;

        var reservations = await _reservationRepository.GetByBookIdAsync(bookId);
        var nextPending = reservations
            .Where(r => r.Status == ReservationStatus.Pending)
            .OrderBy(r => r.QueuePosition)
            .FirstOrDefault();

        if (nextPending is null)
            return null;

        nextPending.Status = ReservationStatus.Confirmed;
        nextPending.UpdatedAt = DateTime.UtcNow;
        await _reservationRepository.UpdateAsync(nextPending);

        var customer = await _customerRepository.GetByIdAsync(nextPending.CustomerId);
        var expiryDays = customer is not null
            ? GetReservationExpiryDays(customer.MembershipType)
            : 3;

        await SendNotificationAsync(
            nextPending.CustomerId,
            "Reservation Ready",
            $"Great news! '{book.Title}' is now available for you. Please pick it up within {expiryDays} days.",
            NotificationType.ReservationReady);

        return nextPending.ToDto();
    }

    private async Task SendNotificationAsync(Guid customerId, string title, string message, NotificationType type)
    {
        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Title = title,
            Message = message,
            Type = type,
            IsRead = false,
            SentAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };
        await _notificationRepository.AddAsync(notification);
    }
}
