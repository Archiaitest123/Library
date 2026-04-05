using Library.Application.DTOs;
using Library.Domain.Enums;

namespace Library.Application.Interfaces;

public interface IReservationQueueService
{
    int GetMembershipPriority(MembershipType membershipType);
    int GetMaxActiveReservations(MembershipType membershipType);
    int GetReservationExpiryDays(MembershipType membershipType);
    Task<BookReservationDto> CreatePrioritizedReservationAsync(CreateBookReservationDto createDto);
    Task<IEnumerable<BookReservationDto>> GetQueueByBookAsync(Guid bookId);
    Task<ReservationQueueStatusDto> GetQueueStatusAsync(Guid bookId);
    Task CancelAndRequeueAsync(Guid reservationId);
    Task<int> ProcessExpiredReservationsAsync();
    Task<BookReservationDto?> PromoteNextInQueueAsync(Guid bookId);
}
