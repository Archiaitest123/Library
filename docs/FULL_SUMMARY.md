namespace Library.Application.Common.Exceptions;

public class BadRequestException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public BadRequestException() : base("Bad request.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public BadRequestException(string message) : base(message)
    {
        Errors = new Dictionary<string, string[]>();
    }

    public BadRequestException(string message, IDictionary<string, string[]> errors) : base(message)
    {
        Errors = errors;
    }
}
namespace Library.Application.Common.Exceptions;

public class ConflictException : Exception
{
    public ConflictException() : base() { }

    public ConflictException(string message) : base(message) { }

    public ConflictException(string message, Exception innerException) : base(message, innerException) { }
}
namespace Library.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base() { }

    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

    public NotFoundException(string entityName, object key)
        : base($"Entity \"{entityName}\" ({key}) was not found.") { }
}
namespace Library.Application.Common.Models;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }

    public static ApiResponse<T> SuccessResponse(T data, string? message = null) => new()
    {
        Success = true,
        Data = data,
        Message = message
    };

    public static ApiResponse<T> FailResponse(string message, IDictionary<string, string[]>? errors = null) => new()
    {
        Success = false,
        Message = message,
        Errors = errors
    };
}
namespace Library.Application.Common.Models;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}
namespace Library.Application.Common.Models;

public class PaginationParams
{
    private const int MaxPageSize = 100;
    private int _pageSize = 10;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
}
namespace Library.Application.DTOs;

public class AuthorDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Nationality { get; set; }
    public string? Website { get; set; }
    public int BookCount { get; set; }
}

public class CreateAuthorDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? Nationality { get; set; }
    public string? Website { get; set; }
}

public class UpdateAuthorDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? Nationality { get; set; }
    public string? Website { get; set; }
}
namespace Library.Application.DTOs;

public class BookCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public string Language { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public BookCondition Condition { get; set; }
    public decimal? Price { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public Guid? PublisherId { get; set; }
    public string? PublisherName { get; set; }
    public Guid? BookCategoryId { get; set; }
    public string? BookCategoryName { get; set; }
    public Guid? LibraryBranchId { get; set; }
    public string? LibraryBranchName { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class BookLoanDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string BookISBN { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public Guid? ProcessedByStaffId { get; set; }
    public string? ProcessedByStaffName { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public LoanStatus Status { get; set; }
    public string? Notes { get; set; }
    public int RenewalCount { get; set; }
    public int MaxRenewals { get; set; }
    public bool IsOverdue { get; set; }
}

public class CreateBookLoanDto
{
    public Guid BookId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? ProcessedByStaffId { get; set; }
    public int LoanDurationDays { get; set; } = 14;
    public string? Notes { get; set; }
}

public class ReturnBookLoanDto
{
    public string? Notes { get; set; }
}

public class RenewBookLoanDto
{
    public int AdditionalDays { get; set; } = 14;
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class BookReservationDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public DateTime ReservationDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ReservationStatus Status { get; set; }
    public int QueuePosition { get; set; }
}

public class CreateBookReservationDto
{
    public Guid BookId { get; set; }
    public Guid CustomerId { get; set; }
    public string? Notes { get; set; }
}
namespace Library.Application.DTOs;

public class BookReviewDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public bool IsApproved { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateBookReviewDto
{
    public Guid BookId { get; set; }
    public Guid CustomerId { get; set; }
    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
}

public class UpdateBookReviewDto
{
    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
}
namespace Library.Application.DTOs;

public class CreateBookCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
namespace Library.Application.DTOs;

public class CreateBookDto
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public string Language { get; set; } = "Turkish";
    public int TotalCopies { get; set; } = 1;
    public decimal? Price { get; set; }
    public Guid AuthorId { get; set; }
    public Guid? PublisherId { get; set; }
    public Guid? BookCategoryId { get; set; }
    public Guid? LibraryBranchId { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class CreateCustomerDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public MembershipType MembershipType { get; set; } = MembershipType.Basic;
    public DateTime? DateOfBirth { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class CreateStaffDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public StaffRole Role { get; set; } = StaffRole.Librarian;
    public decimal? Salary { get; set; }
    public DateTime HireDate { get; set; }
    public Guid? LibraryBranchId { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string MembershipNumber { get; set; } = string.Empty;
    public MembershipType MembershipType { get; set; }
    public DateTime RegisteredDate { get; set; }
    public DateTime? MembershipExpiryDate { get; set; }
    public bool IsActive { get; set; }
    public int MaxBooksAllowed { get; set; }
}
namespace Library.Application.DTOs;

public class DashboardStatsDto
{
    public int TotalBooks { get; set; }
    public int AvailableBooks { get; set; }
    public int TotalCustomers { get; set; }
    public int ActiveCustomers { get; set; }
    public int TotalStaff { get; set; }
    public int ActiveLoans { get; set; }
    public int OverdueLoans { get; set; }
    public int PendingReservations { get; set; }
    public decimal TotalUnpaidFines { get; set; }
    public int TotalBranches { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class FineDto
{
    public Guid Id { get; set; }
    public Guid BookLoanId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BookTitle { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
    public FineStatus Status { get; set; }
    public DateTime? PaidDate { get; set; }
    public string? PaymentMethod { get; set; }
}

public class CreateFineDto
{
    public Guid BookLoanId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class PayFineDto
{
    public string PaymentMethod { get; set; } = string.Empty;
}
namespace Library.Application.DTOs;

public class LibraryBranchDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Description { get; set; }
    public TimeOnly OpeningTime { get; set; }
    public TimeOnly ClosingTime { get; set; }
    public bool IsActive { get; set; }
    public int StaffCount { get; set; }
    public int BookCount { get; set; }
}

public class CreateLibraryBranchDto
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Description { get; set; }
    public TimeOnly OpeningTime { get; set; }
    public TimeOnly ClosingTime { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}

public class UpdateLibraryBranchDto
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Description { get; set; }
    public TimeOnly OpeningTime { get; set; }
    public TimeOnly ClosingTime { get; set; }
    public bool IsActive { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class NotificationDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateNotificationDto
{
    public Guid CustomerId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
}
namespace Library.Application.DTOs;

public class PublisherDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public int? FoundedYear { get; set; }
    public bool IsActive { get; set; }
    public int BookCount { get; set; }
}

public class CreatePublisherDto
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public int? FoundedYear { get; set; }
}

public class UpdatePublisherDto
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public int? FoundedYear { get; set; }
    public bool IsActive { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class StaffDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public StaffRole Role { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    public string? EmployeeNumber { get; set; }
    public Guid? LibraryBranchId { get; set; }
    public string? LibraryBranchName { get; set; }
}
namespace Library.Application.DTOs;

public class UpdateBookCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class UpdateBookDto
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public string Language { get; set; } = "Turkish";
    public bool IsAvailable { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public BookCondition Condition { get; set; }
    public decimal? Price { get; set; }
    public Guid AuthorId { get; set; }
    public Guid? PublisherId { get; set; }
    public Guid? BookCategoryId { get; set; }
    public Guid? LibraryBranchId { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class UpdateCustomerDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public MembershipType MembershipType { get; set; }
    public bool IsActive { get; set; }
}
using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class UpdateStaffDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public StaffRole Role { get; set; }
    public decimal? Salary { get; set; }
    public bool IsActive { get; set; }
    public Guid? LibraryBranchId { get; set; }
}
using Library.Application.Interfaces;
using Library.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookCategoryService, BookCategoryService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IBookLoanService, BookLoanService>();
        services.AddScoped<IBookReservationService, BookReservationService>();
        services.AddScoped<IFineService, FineService>();
        services.AddScoped<ILibraryBranchService, LibraryBranchService>();
        services.AddScoped<IBookReviewService, BookReviewService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IDashboardService, DashboardService>();

        return services;
    }
}
namespace Library.Application.Email;

public class EmailSettings
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 587;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public string NotificationTo { get; set; } = string.Empty;
    public bool EnableSsl { get; set; } = true;
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IAuthorService
{
    Task<AuthorDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<AuthorDto>> GetAllAsync();
    Task<IEnumerable<AuthorDto>> SearchAsync(string searchTerm);
    Task<AuthorDto> CreateAsync(CreateAuthorDto createDto);
    Task UpdateAsync(Guid id, UpdateAuthorDto updateDto);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookCategoryService
{
    Task<BookCategoryDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookCategoryDto>> GetAllAsync();
    Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto);
    Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;
using Library.Domain.Enums;

namespace Library.Application.Interfaces;

public interface IBookLoanService
{
    Task<BookLoanDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookLoanDto>> GetAllAsync();
    Task<IEnumerable<BookLoanDto>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookLoanDto>> GetActiveLoansAsync();
    Task<IEnumerable<BookLoanDto>> GetOverdueLoansAsync();
    Task<IEnumerable<BookLoanDto>> GetByStatusAsync(LoanStatus status);
    Task<BookLoanDto> CreateAsync(CreateBookLoanDto createDto);
    Task<BookLoanDto> ReturnBookAsync(Guid id, ReturnBookLoanDto returnDto);
    Task<BookLoanDto> RenewLoanAsync(Guid id, RenewBookLoanDto renewDto);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookReservationService
{
    Task<BookReservationDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookReservationDto>> GetAllAsync();
    Task<IEnumerable<BookReservationDto>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookReservationDto>> GetByBookIdAsync(Guid bookId);
    Task<BookReservationDto> CreateAsync(CreateBookReservationDto createDto);
    Task CancelReservationAsync(Guid id);
    Task FulfillReservationAsync(Guid id);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookReviewService
{
    Task<BookReviewDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookReviewDto>> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<BookReviewDto>> GetByCustomerIdAsync(Guid customerId);
    Task<double> GetAverageRatingAsync(Guid bookId);
    Task<BookReviewDto> CreateAsync(CreateBookReviewDto createDto);
    Task UpdateAsync(Guid id, UpdateBookReviewDto updateDto);
    Task ApproveReviewAsync(Guid id);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookService
{
    Task<BookDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookDto>> GetAllAsync();
    Task<IEnumerable<BookDto>> GetAvailableBooksAsync();
    Task<BookDto> CreateAsync(CreateBookDto createBookDto);
    Task UpdateAsync(Guid id, UpdateBookDto updateBookDto);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync();
    Task<CustomerDto> CreateAsync(CreateCustomerDto createDto);
    Task UpdateAsync(Guid id, UpdateCustomerDto updateDto);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardStatsDto> GetStatsAsync();
}
namespace Library.Application.Interfaces;

public interface IEmailService
{
    Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IFineService
{
    Task<FineDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<FineDto>> GetAllAsync();
    Task<IEnumerable<FineDto>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<FineDto>> GetPendingFinesAsync();
    Task<decimal> GetTotalUnpaidByCustomerAsync(Guid customerId);
    Task<FineDto> CreateAsync(CreateFineDto createDto);
    Task<FineDto> PayFineAsync(Guid id, PayFineDto payDto);
    Task WaiveFineAsync(Guid id);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface ILibraryBranchService
{
    Task<LibraryBranchDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<LibraryBranchDto>> GetAllAsync();
    Task<IEnumerable<LibraryBranchDto>> GetActiveBranchesAsync();
    Task<LibraryBranchDto> CreateAsync(CreateLibraryBranchDto createDto);
    Task UpdateAsync(Guid id, UpdateLibraryBranchDto updateDto);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<NotificationDto>> GetUnreadByCustomerIdAsync(Guid customerId);
    Task<int> GetUnreadCountAsync(Guid customerId);
    Task<NotificationDto> CreateAsync(CreateNotificationDto createDto);
    Task MarkAsReadAsync(Guid id);
    Task MarkAllAsReadAsync(Guid customerId);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IPublisherService
{
    Task<PublisherDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<PublisherDto>> GetAllAsync();
    Task<IEnumerable<PublisherDto>> GetActivePublishersAsync();
    Task<PublisherDto> CreateAsync(CreatePublisherDto createDto);
    Task UpdateAsync(Guid id, UpdatePublisherDto updateDto);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IStaffService
{
    Task<StaffDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<StaffDto>> GetAllAsync();
    Task<IEnumerable<StaffDto>> GetActiveStaffAsync();
    Task<StaffDto> CreateAsync(CreateStaffDto createDto);
    Task UpdateAsync(Guid id, UpdateStaffDto updateDto);
    Task DeleteAsync(Guid id);
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class AuthorMappings
{
    public static AuthorDto ToDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Biography = author.Biography,
            BirthDate = author.BirthDate,
            Nationality = author.Nationality,
            Website = author.Website,
            BookCount = author.Books?.Count ?? 0
        };
    }

    public static Author ToEntity(this CreateAuthorDto dto)
    {
        return new Author
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Biography = dto.Biography,
            BirthDate = dto.BirthDate,
            DeathDate = dto.DeathDate,
            Nationality = dto.Nationality,
            Website = dto.Website,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateAuthorDto dto, Author author)
    {
        author.FirstName = dto.FirstName;
        author.LastName = dto.LastName;
        author.Biography = dto.Biography;
        author.BirthDate = dto.BirthDate;
        author.DeathDate = dto.DeathDate;
        author.Nationality = dto.Nationality;
        author.Website = dto.Website;
        author.UpdatedAt = DateTime.UtcNow;
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class BookCategoryMappings
{
    public static BookCategoryDto ToDto(this BookCategory category)
    {
        return new BookCategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }

    public static BookCategory ToEntity(this CreateBookCategoryDto dto)
    {
        return new BookCategory
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)
    {
        category.Name = dto.Name;
        category.Description = dto.Description;
        category.UpdatedAt = DateTime.UtcNow;
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Application.Mappings;

public static class BookLoanMappings
{
    public static BookLoanDto ToDto(this BookLoan loan)
    {
        return new BookLoanDto
        {
            Id = loan.Id,
            BookId = loan.BookId,
            BookTitle = loan.Book?.Title ?? string.Empty,
            BookISBN = loan.Book?.ISBN ?? string.Empty,
            CustomerId = loan.CustomerId,
            CustomerName = loan.Customer != null ? $"{loan.Customer.FirstName} {loan.Customer.LastName}" : string.Empty,
            ProcessedByStaffId = loan.ProcessedByStaffId,
            ProcessedByStaffName = loan.ProcessedByStaff != null ? $"{loan.ProcessedByStaff.FirstName} {loan.ProcessedByStaff.LastName}" : null,
            LoanDate = loan.LoanDate,
            DueDate = loan.DueDate,
            ReturnDate = loan.ReturnDate,
            Status = loan.Status,
            Notes = loan.Notes,
            RenewalCount = loan.RenewalCount,
            MaxRenewals = loan.MaxRenewals,
            IsOverdue = loan.Status == LoanStatus.Active && loan.DueDate < DateTime.UtcNow
        };
    }

    public static BookLoan ToEntity(this CreateBookLoanDto dto)
    {
        return new BookLoan
        {
            Id = Guid.NewGuid(),
            BookId = dto.BookId,
            CustomerId = dto.CustomerId,
            ProcessedByStaffId = dto.ProcessedByStaffId,
            LoanDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(dto.LoanDurationDays),
            Status = LoanStatus.Active,
            Notes = dto.Notes,
            RenewalCount = 0,
            MaxRenewals = 2,
            CreatedAt = DateTime.UtcNow
        };
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class BookMappings
{
    public static BookDto ToDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            Description = book.Description,
            PublishedYear = book.PublishedYear,
            PageCount = book.PageCount,
            Language = book.Language,
            IsAvailable = book.IsAvailable,
            TotalCopies = book.TotalCopies,
            AvailableCopies = book.AvailableCopies,
            Condition = book.Condition,
            Price = book.Price,
            AuthorId = book.AuthorId,
            AuthorName = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : string.Empty,
            PublisherId = book.PublisherId,
            PublisherName = book.Publisher?.Name,
            BookCategoryId = book.BookCategoryId,
            BookCategoryName = book.BookCategory?.Name,
            LibraryBranchId = book.LibraryBranchId,
            LibraryBranchName = book.LibraryBranch?.Name
        };
    }

    public static Book ToEntity(this CreateBookDto dto)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            ISBN = dto.ISBN,
            Description = dto.Description,
            PublishedYear = dto.PublishedYear,
            PageCount = dto.PageCount,
            Language = dto.Language,
            IsAvailable = true,
            TotalCopies = dto.TotalCopies,
            AvailableCopies = dto.TotalCopies,
            AuthorId = dto.AuthorId,
            PublisherId = dto.PublisherId,
            BookCategoryId = dto.BookCategoryId,
            LibraryBranchId = dto.LibraryBranchId,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateBookDto dto, Book book)
    {
        book.Title = dto.Title;
        book.ISBN = dto.ISBN;
        book.Description = dto.Description;
        book.PublishedYear = dto.PublishedYear;
        book.PageCount = dto.PageCount;
        book.Language = dto.Language;
        book.IsAvailable = dto.IsAvailable;
        book.TotalCopies = dto.TotalCopies;
        book.AvailableCopies = dto.AvailableCopies;
        book.Condition = dto.Condition;
        book.Price = dto.Price;
        book.AuthorId = dto.AuthorId;
        book.PublisherId = dto.PublisherId;
        book.BookCategoryId = dto.BookCategoryId;
        book.LibraryBranchId = dto.LibraryBranchId;
        book.UpdatedAt = DateTime.UtcNow;
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Application.Mappings;

public static class BookReservationMappings
{
    public static BookReservationDto ToDto(this BookReservation reservation)
    {
        return new BookReservationDto
        {
            Id = reservation.Id,
            BookId = reservation.BookId,
            BookTitle = reservation.Book?.Title ?? string.Empty,
            CustomerId = reservation.CustomerId,
            CustomerName = reservation.Customer != null ? $"{reservation.Customer.FirstName} {reservation.Customer.LastName}" : string.Empty,
            ReservationDate = reservation.ReservationDate,
            ExpiryDate = reservation.ExpiryDate,
            Status = reservation.Status,
            QueuePosition = reservation.QueuePosition
        };
    }

    public static BookReservation ToEntity(this CreateBookReservationDto dto)
    {
        return new BookReservation
        {
            Id = Guid.NewGuid(),
            BookId = dto.BookId,
            CustomerId = dto.CustomerId,
            ReservationDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddDays(3),
            Status = ReservationStatus.Pending,
            Notes = dto.Notes,
            CreatedAt = DateTime.UtcNow
        };
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class BookReviewMappings
{
    public static BookReviewDto ToDto(this BookReview review)
    {
        return new BookReviewDto
        {
            Id = review.Id,
            BookId = review.BookId,
            BookTitle = review.Book?.Title ?? string.Empty,
            CustomerId = review.CustomerId,
            CustomerName = review.Customer != null ? $"{review.Customer.FirstName} {review.Customer.LastName}" : string.Empty,
            Rating = review.Rating,
            Title = review.Title,
            Comment = review.Comment,
            IsApproved = review.IsApproved,
            CreatedAt = review.CreatedAt
        };
    }

    public static BookReview ToEntity(this CreateBookReviewDto dto)
    {
        return new BookReview
        {
            Id = Guid.NewGuid(),
            BookId = dto.BookId,
            CustomerId = dto.CustomerId,
            Rating = dto.Rating,
            Title = dto.Title,
            Comment = dto.Comment,
            IsApproved = false,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateBookReviewDto dto, BookReview review)
    {
        review.Rating = dto.Rating;
        review.Title = dto.Title;
        review.Comment = dto.Comment;
        review.UpdatedAt = DateTime.UtcNow;
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class CustomerMappings
{
    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
            Address = customer.Address,
            City = customer.City,
            MembershipNumber = customer.MembershipNumber,
            MembershipType = customer.MembershipType,
            RegisteredDate = customer.RegisteredDate,
            MembershipExpiryDate = customer.MembershipExpiryDate,
            IsActive = customer.IsActive,
            MaxBooksAllowed = customer.MaxBooksAllowed
        };
    }

    public static Customer ToEntity(this CreateCustomerDto dto)
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address,
            City = dto.City,
            PostalCode = dto.PostalCode,
            MembershipType = dto.MembershipType,
            DateOfBirth = dto.DateOfBirth,
            MembershipNumber = $"LIB-{Guid.NewGuid().ToString("N")[..8].ToUpper()}",
            RegisteredDate = DateTime.UtcNow,
            MembershipExpiryDate = DateTime.UtcNow.AddYears(1),
            IsActive = true,
            MaxBooksAllowed = dto.MembershipType switch
            {
                Domain.Enums.MembershipType.Premium => 10,
                Domain.Enums.MembershipType.Standard => 7,
                Domain.Enums.MembershipType.Student => 5,
                Domain.Enums.MembershipType.Senior => 7,
                _ => 5
            },
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)
    {
        customer.FirstName = dto.FirstName;
        customer.LastName = dto.LastName;
        customer.Email = dto.Email;
        customer.Phone = dto.Phone;
        customer.Address = dto.Address;
        customer.City = dto.City;
        customer.PostalCode = dto.PostalCode;
        customer.MembershipType = dto.MembershipType;
        customer.IsActive = dto.IsActive;
        customer.UpdatedAt = DateTime.UtcNow;
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Application.Mappings;

public static class FineMappings
{
    public static FineDto ToDto(this Fine fine)
    {
        return new FineDto
        {
            Id = fine.Id,
            BookLoanId = fine.BookLoanId,
            CustomerId = fine.CustomerId,
            CustomerName = fine.Customer != null ? $"{fine.Customer.FirstName} {fine.Customer.LastName}" : string.Empty,
            BookTitle = fine.BookLoan?.Book?.Title ?? string.Empty,
            Amount = fine.Amount,
            Reason = fine.Reason,
            Status = fine.Status,
            PaidDate = fine.PaidDate,
            PaymentMethod = fine.PaymentMethod
        };
    }

    public static Fine ToEntity(this CreateFineDto dto)
    {
        return new Fine
        {
            Id = Guid.NewGuid(),
            BookLoanId = dto.BookLoanId,
            CustomerId = dto.CustomerId,
            Amount = dto.Amount,
            Reason = dto.Reason,
            Status = FineStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class LibraryBranchMappings
{
    public static LibraryBranchDto ToDto(this LibraryBranch branch)
    {
        return new LibraryBranchDto
        {
            Id = branch.Id,
            Name = branch.Name,
            Address = branch.Address,
            City = branch.City,
            Phone = branch.Phone,
            Email = branch.Email,
            Description = branch.Description,
            OpeningTime = branch.OpeningTime,
            ClosingTime = branch.ClosingTime,
            IsActive = branch.IsActive,
            StaffCount = branch.Staff?.Count ?? 0,
            BookCount = branch.Books?.Count ?? 0
        };
    }

    public static LibraryBranch ToEntity(this CreateLibraryBranchDto dto)
    {
        return new LibraryBranch
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            PostalCode = dto.PostalCode,
            Phone = dto.Phone,
            Email = dto.Email,
            Description = dto.Description,
            OpeningTime = dto.OpeningTime,
            ClosingTime = dto.ClosingTime,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateLibraryBranchDto dto, LibraryBranch branch)
    {
        branch.Name = dto.Name;
        branch.Address = dto.Address;
        branch.City = dto.City;
        branch.PostalCode = dto.PostalCode;
        branch.Phone = dto.Phone;
        branch.Email = dto.Email;
        branch.Description = dto.Description;
        branch.OpeningTime = dto.OpeningTime;
        branch.ClosingTime = dto.ClosingTime;
        branch.IsActive = dto.IsActive;
        branch.Latitude = dto.Latitude;
        branch.Longitude = dto.Longitude;
        branch.UpdatedAt = DateTime.UtcNow;
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class NotificationMappings
{
    public static NotificationDto ToDto(this Notification notification)
    {
        return new NotificationDto
        {
            Id = notification.Id,
            CustomerId = notification.CustomerId,
            Title = notification.Title,
            Message = notification.Message,
            Type = notification.Type,
            IsRead = notification.IsRead,
            ReadAt = notification.ReadAt,
            CreatedAt = notification.CreatedAt
        };
    }

    public static Notification ToEntity(this CreateNotificationDto dto)
    {
        return new Notification
        {
            Id = Guid.NewGuid(),
            CustomerId = dto.CustomerId,
            Title = dto.Title,
            Message = dto.Message,
            Type = dto.Type,
            IsRead = false,
            SentAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class PublisherMappings
{
    public static PublisherDto ToDto(this Publisher publisher)
    {
        return new PublisherDto
        {
            Id = publisher.Id,
            Name = publisher.Name,
            City = publisher.City,
            Country = publisher.Country,
            Phone = publisher.Phone,
            Email = publisher.Email,
            Website = publisher.Website,
            FoundedYear = publisher.FoundedYear,
            IsActive = publisher.IsActive,
            BookCount = publisher.Books?.Count ?? 0
        };
    }

    public static Publisher ToEntity(this CreatePublisherDto dto)
    {
        return new Publisher
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            Country = dto.Country,
            Phone = dto.Phone,
            Email = dto.Email,
            Website = dto.Website,
            FoundedYear = dto.FoundedYear,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdatePublisherDto dto, Publisher publisher)
    {
        publisher.Name = dto.Name;
        publisher.Address = dto.Address;
        publisher.City = dto.City;
        publisher.Country = dto.Country;
        publisher.Phone = dto.Phone;
        publisher.Email = dto.Email;
        publisher.Website = dto.Website;
        publisher.FoundedYear = dto.FoundedYear;
        publisher.IsActive = dto.IsActive;
        publisher.UpdatedAt = DateTime.UtcNow;
    }
}
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class StaffMappings
{
    public static StaffDto ToDto(this Staff staff)
    {
        return new StaffDto
        {
            Id = staff.Id,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            Email = staff.Email,
            Phone = staff.Phone,
            Position = staff.Position,
            Role = staff.Role,
            HireDate = staff.HireDate,
            IsActive = staff.IsActive,
            EmployeeNumber = staff.EmployeeNumber,
            LibraryBranchId = staff.LibraryBranchId,
            LibraryBranchName = staff.LibraryBranch?.Name
        };
    }

    public static Staff ToEntity(this CreateStaffDto dto)
    {
        return new Staff
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Position = dto.Position,
            Role = dto.Role,
            Salary = dto.Salary,
            HireDate = dto.HireDate,
            LibraryBranchId = dto.LibraryBranchId,
            EmployeeNumber = $"EMP-{Guid.NewGuid().ToString("N")[..6].ToUpper()}",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)
    {
        staff.FirstName = dto.FirstName;
        staff.LastName = dto.LastName;
        staff.Email = dto.Email;
        staff.Phone = dto.Phone;
        staff.Position = dto.Position;
        staff.Role = dto.Role;
        staff.Salary = dto.Salary;
        staff.IsActive = dto.IsActive;
        staff.LibraryBranchId = dto.LibraryBranchId;
        staff.UpdatedAt = DateTime.UtcNow;
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<AuthorDto?> GetByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetWithBooksAsync(id);
        return author?.ToDto();
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return authors.Select(a => a.ToDto());
    }

    public async Task<IEnumerable<AuthorDto>> SearchAsync(string searchTerm)
    {
        var authors = await _authorRepository.SearchAsync(searchTerm);
        return authors.Select(a => a.ToDto());
    }

    public async Task<AuthorDto> CreateAsync(CreateAuthorDto createDto)
    {
        var author = createDto.ToEntity();
        await _authorRepository.AddAsync(author);
        return author.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateAuthorDto updateDto)
    {
        var author = await _authorRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Author), id);

        updateDto.UpdateEntity(author);
        await _authorRepository.UpdateAsync(author);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _authorRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Author), id);

        await _authorRepository.DeleteAsync(id);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookCategoryService : IBookCategoryService
{
    private readonly IBookCategoryRepository _categoryRepository;

    public BookCategoryService(IBookCategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<BookCategoryDto?> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return category?.ToDto();
    }

    public async Task<IEnumerable<BookCategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(c => c.ToDto());
    }

    public async Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)
    {
        var existing = await _categoryRepository.GetByNameAsync(createDto.Name);
        if (existing is not null)
            throw new ConflictException($"Category with name '{createDto.Name}' already exists.");

        var category = createDto.ToEntity();
        await _categoryRepository.AddAsync(category);
        return category.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)
    {
        var category = await _categoryRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookCategory), id);

        updateDto.UpdateEntity(category);
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _categoryRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookCategory), id);

        await _categoryRepository.DeleteAsync(id);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookLoanService : IBookLoanService
{
    private readonly IBookLoanRepository _loanRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;

    public BookLoanService(
        IBookLoanRepository loanRepository,
        IBookRepository bookRepository,
        ICustomerRepository customerRepository)
    {
        _loanRepository = loanRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
    }

    public async Task<BookLoanDto?> GetByIdAsync(Guid id)
    {
        var loan = await _loanRepository.GetWithDetailsAsync(id);
        return loan?.ToDto();
    }

    public async Task<IEnumerable<BookLoanDto>> GetAllAsync()
    {
        var loans = await _loanRepository.GetAllAsync();
        return loans.Select(l => l.ToDto());
    }

    public async Task<IEnumerable<BookLoanDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var loans = await _loanRepository.GetByCustomerIdAsync(customerId);
        return loans.Select(l => l.ToDto());
    }

    public async Task<IEnumerable<BookLoanDto>> GetActiveLoansAsync()
    {
        var loans = await _loanRepository.GetActiveLoansAsync();
        return loans.Select(l => l.ToDto());
    }

    public async Task<IEnumerable<BookLoanDto>> GetOverdueLoansAsync()
    {
        var loans = await _loanRepository.GetOverdueLoansAsync();
        return loans.Select(l => l.ToDto());
    }

    public async Task<IEnumerable<BookLoanDto>> GetByStatusAsync(LoanStatus status)
    {
        var loans = await _loanRepository.GetByStatusAsync(status);
        return loans.Select(l => l.ToDto());
    }

    public async Task<BookLoanDto> CreateAsync(CreateBookLoanDto createDto)
    {
        var book = await _bookRepository.GetByIdAsync(createDto.BookId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Book), createDto.BookId);

        if (book.AvailableCopies <= 0)
            throw new BadRequestException("No available copies of this book.");

        var customer = await _customerRepository.GetByIdAsync(createDto.CustomerId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Customer), createDto.CustomerId);

        if (!customer.IsActive)
            throw new BadRequestException("Customer membership is not active.");

        var activeLoanCount = await _loanRepository.GetActiveLoanCountByCustomerAsync(createDto.CustomerId);
        if (activeLoanCount >= customer.MaxBooksAllowed)
            throw new BadRequestException($"Customer has reached the maximum loan limit of {customer.MaxBooksAllowed}.");

        var loan = createDto.ToEntity();
        await _loanRepository.AddAsync(loan);

        book.AvailableCopies--;
        if (book.AvailableCopies == 0)
            book.IsAvailable = false;
        await _bookRepository.UpdateAsync(book);

        return loan.ToDto();
    }

    public async Task<BookLoanDto> ReturnBookAsync(Guid id, ReturnBookLoanDto returnDto)
    {
        var loan = await _loanRepository.GetWithDetailsAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookLoan), id);

        if (loan.Status != LoanStatus.Active && loan.Status != LoanStatus.Overdue)
            throw new BadRequestException("This loan is not active.");

        loan.ReturnDate = DateTime.UtcNow;
        loan.Status = LoanStatus.Returned;
        loan.Notes = returnDto.Notes;
        loan.UpdatedAt = DateTime.UtcNow;
        await _loanRepository.UpdateAsync(loan);

        var book = await _bookRepository.GetByIdAsync(loan.BookId);
        if (book is not null)
        {
            book.AvailableCopies++;
            book.IsAvailable = true;
            await _bookRepository.UpdateAsync(book);
        }

        return loan.ToDto();
    }

    public async Task<BookLoanDto> RenewLoanAsync(Guid id, RenewBookLoanDto renewDto)
    {
        var loan = await _loanRepository.GetWithDetailsAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookLoan), id);

        if (loan.Status != LoanStatus.Active)
            throw new BadRequestException("Only active loans can be renewed.");

        if (loan.RenewalCount >= loan.MaxRenewals)
            throw new BadRequestException($"Maximum renewal limit ({loan.MaxRenewals}) reached.");

        loan.DueDate = loan.DueDate.AddDays(renewDto.AdditionalDays);
        loan.RenewalCount++;
        loan.UpdatedAt = DateTime.UtcNow;
        await _loanRepository.UpdateAsync(loan);

        return loan.ToDto();
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _loanRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookLoan), id);

        await _loanRepository.DeleteAsync(id);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookReservationService : IBookReservationService
{
    private readonly IBookReservationRepository _reservationRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;

    public BookReservationService(
        IBookReservationRepository reservationRepository,
        IBookRepository bookRepository,
        ICustomerRepository customerRepository)
    {
        _reservationRepository = reservationRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
    }

    public async Task<BookReservationDto?> GetByIdAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetWithDetailsAsync(id);
        return reservation?.ToDto();
    }

    public async Task<IEnumerable<BookReservationDto>> GetAllAsync()
    {
        var reservations = await _reservationRepository.GetAllAsync();
        return reservations.Select(r => r.ToDto());
    }

    public async Task<IEnumerable<BookReservationDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var reservations = await _reservationRepository.GetByCustomerIdAsync(customerId);
        return reservations.Select(r => r.ToDto());
    }

    public async Task<IEnumerable<BookReservationDto>> GetByBookIdAsync(Guid bookId)
    {
        var reservations = await _reservationRepository.GetByBookIdAsync(bookId);
        return reservations.Select(r => r.ToDto());
    }

    public async Task<BookReservationDto> CreateAsync(CreateBookReservationDto createDto)
    {
        if (!await _bookRepository.ExistsAsync(createDto.BookId))
            throw new NotFoundException(nameof(Domain.Entities.Book), createDto.BookId);

        var customer = await _customerRepository.GetByIdAsync(createDto.CustomerId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Customer), createDto.CustomerId);

        if (!customer.IsActive)
            throw new BadRequestException("Customer membership is not active.");

        var existingReservations = await _reservationRepository.GetByBookIdAsync(createDto.BookId);
        var queuePosition = existingReservations.Count(r => r.Status == ReservationStatus.Pending) + 1;

        var reservation = createDto.ToEntity();
        reservation.QueuePosition = queuePosition;
        await _reservationRepository.AddAsync(reservation);

        return reservation.ToDto();
    }

    public async Task CancelReservationAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookReservation), id);

        reservation.Status = ReservationStatus.Cancelled;
        reservation.UpdatedAt = DateTime.UtcNow;
        await _reservationRepository.UpdateAsync(reservation);
    }

    public async Task FulfillReservationAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookReservation), id);

        reservation.Status = ReservationStatus.Fulfilled;
        reservation.UpdatedAt = DateTime.UtcNow;
        await _reservationRepository.UpdateAsync(reservation);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _reservationRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookReservation), id);

        await _reservationRepository.DeleteAsync(id);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookReviewService : IBookReviewService
{
    private readonly IBookReviewRepository _reviewRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;

    public BookReviewService(
        IBookReviewRepository reviewRepository,
        IBookRepository bookRepository,
        ICustomerRepository customerRepository)
    {
        _reviewRepository = reviewRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
    }

    public async Task<BookReviewDto?> GetByIdAsync(Guid id)
    {
        var review = await _reviewRepository.GetByIdAsync(id);
        return review?.ToDto();
    }

    public async Task<IEnumerable<BookReviewDto>> GetByBookIdAsync(Guid bookId)
    {
        var reviews = await _reviewRepository.GetApprovedReviewsByBookAsync(bookId);
        return reviews.Select(r => r.ToDto());
    }

    public async Task<IEnumerable<BookReviewDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var reviews = await _reviewRepository.GetByCustomerIdAsync(customerId);
        return reviews.Select(r => r.ToDto());
    }

    public async Task<double> GetAverageRatingAsync(Guid bookId)
    {
        return await _reviewRepository.GetAverageRatingByBookAsync(bookId);
    }

    public async Task<BookReviewDto> CreateAsync(CreateBookReviewDto createDto)
    {
        if (!await _bookRepository.ExistsAsync(createDto.BookId))
            throw new NotFoundException(nameof(Domain.Entities.Book), createDto.BookId);

        if (!await _customerRepository.ExistsAsync(createDto.CustomerId))
            throw new NotFoundException(nameof(Domain.Entities.Customer), createDto.CustomerId);

        if (createDto.Rating < 1 || createDto.Rating > 5)
            throw new BadRequestException("Rating must be between 1 and 5.");

        var review = createDto.ToEntity();
        await _reviewRepository.AddAsync(review);
        return review.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateBookReviewDto updateDto)
    {
        var review = await _reviewRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookReview), id);

        if (updateDto.Rating < 1 || updateDto.Rating > 5)
            throw new BadRequestException("Rating must be between 1 and 5.");

        updateDto.UpdateEntity(review);
        await _reviewRepository.UpdateAsync(review);
    }

    public async Task ApproveReviewAsync(Guid id)
    {
        var review = await _reviewRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookReview), id);

        review.IsApproved = true;
        review.UpdatedAt = DateTime.UtcNow;
        await _reviewRepository.UpdateAsync(review);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _reviewRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookReview), id);

        await _reviewRepository.DeleteAsync(id);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Email;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IEmailService _emailService;
    private readonly EmailSettings _emailSettings;

    public BookService(IBookRepository bookRepository, IEmailService emailService, EmailSettings emailSettings)
    {
        _bookRepository = bookRepository;
        _emailService = emailService;
        _emailSettings = emailSettings;
    }

    public async Task<BookDto?> GetByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetWithDetailsAsync(id);
        return book?.ToDto();
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books.Select(b => b.ToDto());
    }

    public async Task<IEnumerable<BookDto>> GetAvailableBooksAsync()
    {
        var books = await _bookRepository.GetAvailableBooksAsync();
        return books.Select(b => b.ToDto());
    }

    public async Task<BookDto> CreateAsync(CreateBookDto createBookDto)
    {
        var existingBook = await _bookRepository.GetByISBNAsync(createBookDto.ISBN);
        if (existingBook is not null)
            throw new ConflictException($"A book with ISBN '{createBookDto.ISBN}' already exists.");

        var book = createBookDto.ToEntity();
        await _bookRepository.AddAsync(book);
        await SendBookAddedNotificationAsync(book);
        return book.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)
    {
        var book = await _bookRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Book), id);

        updateBookDto.UpdateEntity(book);
        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _bookRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Book), id);

        await _bookRepository.DeleteAsync(id);
    }

    private Task SendBookAddedNotificationAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(_emailSettings.NotificationTo))
        {
            return Task.CompletedTask;
        }

        var subject = $"New book added: {book.Title}";
        var body = $"<p>A new book was added.</p><ul><li>Title: {book.Title}</li><li>Author: {book.Author}</li><li>ISBN: {book.ISBN}</li><li>Published Year: {book.PublishedYear}</li></ul>";
        return _emailService.SendAsync(_emailSettings.NotificationTo, subject, body, true);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto?> GetByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return customer?.ToDto();
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers.Select(c => c.ToDto());
    }

    public async Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()
    {
        var customers = await _customerRepository.GetActiveCustomersAsync();
        return customers.Select(c => c.ToDto());
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)
    {
        var existing = await _customerRepository.GetByEmailAsync(createDto.Email);
        if (existing is not null)
            throw new ConflictException($"A customer with email '{createDto.Email}' already exists.");

        var customer = createDto.ToEntity();
        await _customerRepository.AddAsync(customer);
        return customer.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)
    {
        var customer = await _customerRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Customer), id);

        updateDto.UpdateEntity(customer);
        await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _customerRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Customer), id);

        await _customerRepository.DeleteAsync(id);
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IStaffRepository _staffRepository;
    private readonly IBookLoanRepository _loanRepository;
    private readonly IBookReservationRepository _reservationRepository;
    private readonly IFineRepository _fineRepository;
    private readonly ILibraryBranchRepository _branchRepository;

    public DashboardService(
        IBookRepository bookRepository,
        ICustomerRepository customerRepository,
        IStaffRepository staffRepository,
        IBookLoanRepository loanRepository,
        IBookReservationRepository reservationRepository,
        IFineRepository fineRepository,
        ILibraryBranchRepository branchRepository)
    {
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
        _staffRepository = staffRepository;
        _loanRepository = loanRepository;
        _reservationRepository = reservationRepository;
        _fineRepository = fineRepository;
        _branchRepository = branchRepository;
    }

    public async Task<DashboardStatsDto> GetStatsAsync()
    {
        var totalBooks = await _bookRepository.CountAsync();
        var availableBooks = await _bookRepository.CountAsync(b => b.IsAvailable);
        var totalCustomers = await _customerRepository.CountAsync();
        var activeCustomers = (await _customerRepository.GetActiveCustomersAsync()).Count();
        var totalStaff = await _staffRepository.CountAsync();
        var activeLoans = (await _loanRepository.GetActiveLoansAsync()).Count();
        var overdueLoans = (await _loanRepository.GetOverdueLoansAsync()).Count();
        var pendingReservations = (await _reservationRepository.GetByStatusAsync(ReservationStatus.Pending)).Count();
        var pendingFines = await _fineRepository.GetPendingFinesAsync();
        var totalUnpaidFines = pendingFines.Sum(f => f.Amount);
        var totalBranches = await _branchRepository.CountAsync();

        return new DashboardStatsDto
        {
            TotalBooks = totalBooks,
            AvailableBooks = availableBooks,
            TotalCustomers = totalCustomers,
            ActiveCustomers = activeCustomers,
            TotalStaff = totalStaff,
            ActiveLoans = activeLoans,
            OverdueLoans = overdueLoans,
            PendingReservations = pendingReservations,
            TotalUnpaidFines = totalUnpaidFines,
            TotalBranches = totalBranches
        };
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class FineService : IFineService
{
    private readonly IFineRepository _fineRepository;

    public FineService(IFineRepository fineRepository)
    {
        _fineRepository = fineRepository;
    }

    public async Task<FineDto?> GetByIdAsync(Guid id)
    {
        var fine = await _fineRepository.GetByIdAsync(id);
        return fine?.ToDto();
    }

    public async Task<IEnumerable<FineDto>> GetAllAsync()
    {
        var fines = await _fineRepository.GetAllAsync();
        return fines.Select(f => f.ToDto());
    }

    public async Task<IEnumerable<FineDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var fines = await _fineRepository.GetByCustomerIdAsync(customerId);
        return fines.Select(f => f.ToDto());
    }

    public async Task<IEnumerable<FineDto>> GetPendingFinesAsync()
    {
        var fines = await _fineRepository.GetPendingFinesAsync();
        return fines.Select(f => f.ToDto());
    }

    public async Task<decimal> GetTotalUnpaidByCustomerAsync(Guid customerId)
    {
        return await _fineRepository.GetTotalUnpaidFinesByCustomerAsync(customerId);
    }

    public async Task<FineDto> CreateAsync(CreateFineDto createDto)
    {
        var fine = createDto.ToEntity();
        await _fineRepository.AddAsync(fine);
        return fine.ToDto();
    }

    public async Task<FineDto> PayFineAsync(Guid id, PayFineDto payDto)
    {
        var fine = await _fineRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Fine), id);

        if (fine.Status == FineStatus.Paid)
            throw new BadRequestException("This fine has already been paid.");

        fine.Status = FineStatus.Paid;
        fine.PaidDate = DateTime.UtcNow;
        fine.PaymentMethod = payDto.PaymentMethod;
        fine.UpdatedAt = DateTime.UtcNow;
        await _fineRepository.UpdateAsync(fine);

        return fine.ToDto();
    }

    public async Task WaiveFineAsync(Guid id)
    {
        var fine = await _fineRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Fine), id);

        fine.Status = FineStatus.Waived;
        fine.UpdatedAt = DateTime.UtcNow;
        await _fineRepository.UpdateAsync(fine);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _fineRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Fine), id);

        await _fineRepository.DeleteAsync(id);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class LibraryBranchService : ILibraryBranchService
{
    private readonly ILibraryBranchRepository _branchRepository;

    public LibraryBranchService(ILibraryBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<LibraryBranchDto?> GetByIdAsync(Guid id)
    {
        var branch = await _branchRepository.GetByIdAsync(id);
        return branch?.ToDto();
    }

    public async Task<IEnumerable<LibraryBranchDto>> GetAllAsync()
    {
        var branches = await _branchRepository.GetAllAsync();
        return branches.Select(b => b.ToDto());
    }

    public async Task<IEnumerable<LibraryBranchDto>> GetActiveBranchesAsync()
    {
        var branches = await _branchRepository.GetActiveBranchesAsync();
        return branches.Select(b => b.ToDto());
    }

    public async Task<LibraryBranchDto> CreateAsync(CreateLibraryBranchDto createDto)
    {
        var branch = createDto.ToEntity();
        await _branchRepository.AddAsync(branch);
        return branch.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateLibraryBranchDto updateDto)
    {
        var branch = await _branchRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.LibraryBranch), id);

        updateDto.UpdateEntity(branch);
        await _branchRepository.UpdateAsync(branch);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _branchRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.LibraryBranch), id);

        await _branchRepository.DeleteAsync(id);
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<IEnumerable<NotificationDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var notifications = await _notificationRepository.GetByCustomerIdAsync(customerId);
        return notifications.Select(n => n.ToDto());
    }

    public async Task<IEnumerable<NotificationDto>> GetUnreadByCustomerIdAsync(Guid customerId)
    {
        var notifications = await _notificationRepository.GetUnreadByCustomerIdAsync(customerId);
        return notifications.Select(n => n.ToDto());
    }

    public async Task<int> GetUnreadCountAsync(Guid customerId)
    {
        return await _notificationRepository.GetUnreadCountByCustomerIdAsync(customerId);
    }

    public async Task<NotificationDto> CreateAsync(CreateNotificationDto createDto)
    {
        var notification = createDto.ToEntity();
        await _notificationRepository.AddAsync(notification);
        return notification.ToDto();
    }

    public async Task MarkAsReadAsync(Guid id)
    {
        await _notificationRepository.MarkAsReadAsync(id);
    }

    public async Task MarkAllAsReadAsync(Guid customerId)
    {
        await _notificationRepository.MarkAllAsReadAsync(customerId);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _notificationRepository.DeleteAsync(id);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<PublisherDto?> GetByIdAsync(Guid id)
    {
        var publisher = await _publisherRepository.GetWithBooksAsync(id);
        return publisher?.ToDto();
    }

    public async Task<IEnumerable<PublisherDto>> GetAllAsync()
    {
        var publishers = await _publisherRepository.GetAllAsync();
        return publishers.Select(p => p.ToDto());
    }

    public async Task<IEnumerable<PublisherDto>> GetActivePublishersAsync()
    {
        var publishers = await _publisherRepository.GetActivePublishersAsync();
        return publishers.Select(p => p.ToDto());
    }

    public async Task<PublisherDto> CreateAsync(CreatePublisherDto createDto)
    {
        var existing = await _publisherRepository.GetByNameAsync(createDto.Name);
        if (existing is not null)
            throw new ConflictException($"Publisher with name '{createDto.Name}' already exists.");

        var publisher = createDto.ToEntity();
        await _publisherRepository.AddAsync(publisher);
        return publisher.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdatePublisherDto updateDto)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Publisher), id);

        updateDto.UpdateEntity(publisher);
        await _publisherRepository.UpdateAsync(publisher);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _publisherRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Publisher), id);

        await _publisherRepository.DeleteAsync(id);
    }
}
using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class StaffService : IStaffService
{
    private readonly IStaffRepository _staffRepository;

    public StaffService(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<StaffDto?> GetByIdAsync(Guid id)
    {
        var staff = await _staffRepository.GetByIdAsync(id);
        return staff?.ToDto();
    }

    public async Task<IEnumerable<StaffDto>> GetAllAsync()
    {
        var staffList = await _staffRepository.GetAllAsync();
        return staffList.Select(s => s.ToDto());
    }

    public async Task<IEnumerable<StaffDto>> GetActiveStaffAsync()
    {
        var staffList = await _staffRepository.GetActiveStaffAsync();
        return staffList.Select(s => s.ToDto());
    }

    public async Task<StaffDto> CreateAsync(CreateStaffDto createDto)
    {
        var existing = await _staffRepository.GetByEmailAsync(createDto.Email);
        if (existing is not null)
            throw new ConflictException($"A staff member with email '{createDto.Email}' already exists.");

        var staff = createDto.ToEntity();
        await _staffRepository.AddAsync(staff);
        return staff.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateStaffDto updateDto)
    {
        var staff = await _staffRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Staff), id);

        updateDto.UpdateEntity(staff);
        await _staffRepository.UpdateAsync(staff);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _staffRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Staff), id);

        await _staffRepository.DeleteAsync(id);
    }
}
namespace Library.Domain.Entities;

public class AuditLog : BaseEntity
{
    public string EntityName { get; set; } = string.Empty;
    public Guid EntityId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? IpAddress { get; set; }
    public DateTime Timestamp { get; set; }
}
namespace Library.Domain.Entities;

public class Author : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? Nationality { get; set; }
    public string? Website { get; set; }
    public string? PhotoUrl { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}
namespace Library.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public string Language { get; set; } = "Turkish";
    public bool IsAvailable { get; set; } = true;
    public int TotalCopies { get; set; } = 1;
    public int AvailableCopies { get; set; } = 1;
    public BookCondition Condition { get; set; } = BookCondition.New;
    public string? CoverImageUrl { get; set; }
    public decimal? Price { get; set; }

    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public Guid? PublisherId { get; set; }
    public Publisher? Publisher { get; set; }

    public Guid? BookCategoryId { get; set; }
    public BookCategory? BookCategory { get; set; }

    public Guid? LibraryBranchId { get; set; }
    public LibraryBranch? LibraryBranch { get; set; }

    public ICollection<BookLoan> BookLoans { get; set; } = [];
    public ICollection<BookReservation> BookReservations { get; set; } = [];
    public ICollection<BookReview> BookReviews { get; set; } = [];
}
namespace Library.Domain.Entities;

public class BookCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? IconUrl { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;

    public Guid? ParentCategoryId { get; set; }
    public BookCategory? ParentCategory { get; set; }

    public ICollection<BookCategory> SubCategories { get; set; } = [];
    public ICollection<Book> Books { get; set; } = [];
}
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class BookLoan : BaseEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public Guid? ProcessedByStaffId { get; set; }
    public Staff? ProcessedByStaff { get; set; }

    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public LoanStatus Status { get; set; } = LoanStatus.Active;
    public string? Notes { get; set; }
    public int RenewalCount { get; set; }
    public int MaxRenewals { get; set; } = 2;

    public ICollection<Fine> Fines { get; set; } = [];
}
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class BookReservation : BaseEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public DateTime ReservationDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    public string? Notes { get; set; }
    public int QueuePosition { get; set; }
}
namespace Library.Domain.Entities;

public class BookReview : BaseEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public bool IsApproved { get; set; }
}
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public string MembershipNumber { get; set; } = string.Empty;
    public MembershipType MembershipType { get; set; } = MembershipType.Basic;
    public DateTime RegisteredDate { get; set; }
    public DateTime? MembershipExpiryDate { get; set; }
    public bool IsActive { get; set; } = true;
    public int MaxBooksAllowed { get; set; } = 5;
    public string? ProfileImageUrl { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public ICollection<BookLoan> BookLoans { get; set; } = [];
    public ICollection<BookReservation> BookReservations { get; set; } = [];
    public ICollection<BookReview> BookReviews { get; set; } = [];
    public ICollection<Fine> Fines { get; set; } = [];
    public ICollection<Notification> Notifications { get; set; } = [];
}
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class Fine : BaseEntity
{
    public Guid BookLoanId { get; set; }
    public BookLoan BookLoan { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
    public FineStatus Status { get; set; } = FineStatus.Pending;
    public DateTime? PaidDate { get; set; }
    public string? PaymentMethod { get; set; }
}
namespace Library.Domain.Entities;

public class LibraryBranch : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Description { get; set; }
    public TimeOnly OpeningTime { get; set; }
    public TimeOnly ClosingTime { get; set; }
    public bool IsActive { get; set; } = true;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public ICollection<Book> Books { get; set; } = [];
    public ICollection<Staff> Staff { get; set; } = [];
}
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public DateTime? SentAt { get; set; }
}
namespace Library.Domain.Entities;

public class Publisher : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public int? FoundedYear { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Book> Books { get; set; } = [];
}
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class Staff : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public StaffRole Role { get; set; } = StaffRole.Librarian;
    public decimal? Salary { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? EmployeeNumber { get; set; }

    public Guid? LibraryBranchId { get; set; }
    public LibraryBranch? LibraryBranch { get; set; }

    public ICollection<BookLoan> ProcessedLoans { get; set; } = [];
}
namespace Library.Domain.Enums;

public enum LoanStatus
{
    Active,
    Returned,
    Overdue,
    Lost
}

public enum ReservationStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Fulfilled,
    Expired
}

public enum FineStatus
{
    Pending,
    Paid,
    Waived
}

public enum NotificationType
{
    LoanDueReminder,
    LoanOverdue,
    ReservationReady,
    ReservationExpired,
    FineIssued,
    General
}

public enum MembershipType
{
    Basic,
    Standard,
    Premium,
    Student,
    Senior
}

public enum BookCondition
{
    New,
    Good,
    Fair,
    Poor,
    Damaged,
    Lost
}

public enum StaffRole
{
    Librarian,
    SeniorLibrarian,
    AssistantManager,
    Manager,
    Director,
    ITSupport,
    Volunteer
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IAuditLogRepository : IRepository<AuditLog>
{
    Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityName, Guid entityId);
    Task<IEnumerable<AuditLog>> GetByUserAsync(string userId);
    Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IAuthorRepository : IRepository<Author>
{
    Task<IEnumerable<Author>> SearchAsync(string searchTerm);
    Task<Author?> GetWithBooksAsync(Guid id);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookCategoryRepository : IRepository<BookCategory>
{
    Task<BookCategory?> GetByNameAsync(string name);
    Task<BookCategory?> GetWithBooksAsync(Guid id);
    Task<IEnumerable<BookCategory>> GetActiveCategoriesAsync();
    Task<IEnumerable<BookCategory>> GetRootCategoriesAsync();
    Task<IEnumerable<BookCategory>> GetSubCategoriesAsync(Guid parentId);
}
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Domain.Interfaces;

public interface IBookLoanRepository : IRepository<BookLoan>
{
    Task<IEnumerable<BookLoan>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookLoan>> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<BookLoan>> GetActiveLoansAsync();
    Task<IEnumerable<BookLoan>> GetOverdueLoansAsync();
    Task<IEnumerable<BookLoan>> GetByStatusAsync(LoanStatus status);
    Task<BookLoan?> GetWithDetailsAsync(Guid id);
    Task<int> GetActiveLoanCountByCustomerAsync(Guid customerId);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetAvailableBooksAsync();
    Task<Book?> GetByISBNAsync(string isbn);
    Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId);
    Task<IEnumerable<Book>> GetByCategoryIdAsync(Guid categoryId);
    Task<IEnumerable<Book>> GetByBranchIdAsync(Guid branchId);
    Task<IEnumerable<Book>> GetByPublisherIdAsync(Guid publisherId);
    Task<IEnumerable<Book>> SearchAsync(string searchTerm);
    Task<Book?> GetWithDetailsAsync(Guid id);
}
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Domain.Interfaces;

public interface IBookReservationRepository : IRepository<BookReservation>
{
    Task<IEnumerable<BookReservation>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookReservation>> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<BookReservation>> GetByStatusAsync(ReservationStatus status);
    Task<IEnumerable<BookReservation>> GetExpiredReservationsAsync();
    Task<BookReservation?> GetWithDetailsAsync(Guid id);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookReviewRepository : IRepository<BookReview>
{
    Task<IEnumerable<BookReview>> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<BookReview>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookReview>> GetApprovedReviewsByBookAsync(Guid bookId);
    Task<double> GetAverageRatingByBookAsync(Guid bookId);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByEmailAsync(string email);
    Task<Customer?> GetByMembershipNumberAsync(string membershipNumber);
    Task<IEnumerable<Customer>> GetActiveCustomersAsync();
    Task<Customer?> GetWithLoansAsync(Guid id);
    Task<Customer?> GetWithReservationsAsync(Guid id);
    Task<IEnumerable<Customer>> SearchAsync(string searchTerm);
}
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Domain.Interfaces;

public interface IFineRepository : IRepository<Fine>
{
    Task<IEnumerable<Fine>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<Fine>> GetByStatusAsync(FineStatus status);
    Task<IEnumerable<Fine>> GetPendingFinesAsync();
    Task<decimal> GetTotalUnpaidFinesByCustomerAsync(Guid customerId);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface ILibraryBranchRepository : IRepository<LibraryBranch>
{
    Task<IEnumerable<LibraryBranch>> GetActiveBranchesAsync();
    Task<LibraryBranch?> GetWithStaffAsync(Guid id);
    Task<LibraryBranch?> GetWithBooksAsync(Guid id);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface INotificationRepository : IRepository<Notification>
{
    Task<IEnumerable<Notification>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<Notification>> GetUnreadByCustomerIdAsync(Guid customerId);
    Task<int> GetUnreadCountByCustomerIdAsync(Guid customerId);
    Task MarkAsReadAsync(Guid id);
    Task MarkAllAsReadAsync(Guid customerId);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IPublisherRepository : IRepository<Publisher>
{
    Task<Publisher?> GetByNameAsync(string name);
    Task<Publisher?> GetWithBooksAsync(Guid id);
    Task<IEnumerable<Publisher>> GetActivePublishersAsync();
}
using System.Linq.Expressions;

namespace Library.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IStaffRepository : IRepository<Staff>
{
    Task<Staff?> GetByEmailAsync(string email);
    Task<IEnumerable<Staff>> GetActiveStaffAsync();
    Task<IEnumerable<Staff>> GetByBranchIdAsync(Guid branchId);
    Task<Staff?> GetByEmployeeNumberAsync(string employeeNumber);
}
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<BookCategory> BookCategories => Set<BookCategory>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Staff> Staff => Set<Staff>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<BookLoan> BookLoans => Set<BookLoan>();
    public DbSet<BookReservation> BookReservations => Set<BookReservation>();
    public DbSet<Fine> Fines => Set<Fine>();
    public DbSet<LibraryBranch> LibraryBranches => Set<LibraryBranch>();
    public DbSet<BookReview> BookReviews => Set<BookReview>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Global query filter for soft delete
        modelBuilder.Entity<Book>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookCategory>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Author>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Publisher>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Staff>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Customer>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookLoan>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookReservation>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Fine>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<LibraryBranch>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookReview>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Notification>().HasQueryFilter(e => !e.IsDeleted);

        // Author
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.LastName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Biography).HasMaxLength(2000);
            entity.Property(a => a.Nationality).HasMaxLength(100);
            entity.Property(a => a.Website).HasMaxLength(500);
        });

        // Publisher
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Address).HasMaxLength(500);
            entity.Property(p => p.City).HasMaxLength(100);
            entity.Property(p => p.Country).HasMaxLength(100);
            entity.Property(p => p.Phone).HasMaxLength(20);
            entity.Property(p => p.Email).HasMaxLength(200);
            entity.Property(p => p.Website).HasMaxLength(500);
            entity.HasIndex(p => p.Name);
        });

        // Book
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Title).IsRequired().HasMaxLength(300);
            entity.Property(b => b.ISBN).IsRequired().HasMaxLength(20);
            entity.Property(b => b.Description).HasMaxLength(2000);
            entity.Property(b => b.Language).HasMaxLength(50);
            entity.Property(b => b.CoverImageUrl).HasMaxLength(1000);
            entity.Property(b => b.Price).HasPrecision(10, 2);
            entity.HasIndex(b => b.ISBN).IsUnique();
            entity.HasIndex(b => b.Title);

            entity.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(b => b.BookCategory)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.BookCategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(b => b.LibraryBranch)
                .WithMany(lb => lb.Books)
                .HasForeignKey(b => b.LibraryBranchId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // BookCategory
        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Description).HasMaxLength(500);
            entity.Property(c => c.IconUrl).HasMaxLength(500);
            entity.HasIndex(c => c.Name).IsUnique();

            entity.HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Staff
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(s => s.LastName).IsRequired().HasMaxLength(100);
            entity.Property(s => s.Email).IsRequired().HasMaxLength(200);
            entity.Property(s => s.Phone).HasMaxLength(20);
            entity.Property(s => s.Position).IsRequired().HasMaxLength(100);
            entity.Property(s => s.EmployeeNumber).HasMaxLength(20);
            entity.Property(s => s.Salary).HasPrecision(10, 2);
            entity.HasIndex(s => s.Email).IsUnique();
            entity.HasIndex(s => s.EmployeeNumber).IsUnique().HasFilter("[EmployeeNumber] IS NOT NULL");

            entity.HasOne(s => s.LibraryBranch)
                .WithMany(lb => lb.Staff)
                .HasForeignKey(s => s.LibraryBranchId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // Customer
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Email).IsRequired().HasMaxLength(200);
            entity.Property(c => c.Phone).HasMaxLength(20);
            entity.Property(c => c.Address).HasMaxLength(500);
            entity.Property(c => c.City).HasMaxLength(100);
            entity.Property(c => c.PostalCode).HasMaxLength(20);
            entity.Property(c => c.MembershipNumber).IsRequired().HasMaxLength(50);
            entity.Property(c => c.ProfileImageUrl).HasMaxLength(1000);
            entity.HasIndex(c => c.Email).IsUnique();
            entity.HasIndex(c => c.MembershipNumber).IsUnique();
        });

        // BookLoan
        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Notes).HasMaxLength(1000);
            entity.HasIndex(l => l.Status);
            entity.HasIndex(l => l.DueDate);

            entity.HasOne(l => l.Book)
                .WithMany(b => b.BookLoans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(l => l.Customer)
                .WithMany(c => c.BookLoans)
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(l => l.ProcessedByStaff)
                .WithMany(s => s.ProcessedLoans)
                .HasForeignKey(l => l.ProcessedByStaffId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // BookReservation
        modelBuilder.Entity<BookReservation>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Notes).HasMaxLength(1000);
            entity.HasIndex(r => r.Status);

            entity.HasOne(r => r.Book)
                .WithMany(b => b.BookReservations)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Customer)
                .WithMany(c => c.BookReservations)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Fine
        modelBuilder.Entity<Fine>(entity =>
        {
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Amount).HasPrecision(10, 2);
            entity.Property(f => f.Reason).IsRequired().HasMaxLength(500);
            entity.Property(f => f.PaymentMethod).HasMaxLength(50);
            entity.HasIndex(f => f.Status);

            entity.HasOne(f => f.BookLoan)
                .WithMany(l => l.Fines)
                .HasForeignKey(f => f.BookLoanId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(f => f.Customer)
                .WithMany(c => c.Fines)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // LibraryBranch
        modelBuilder.Entity<LibraryBranch>(entity =>
        {
            entity.HasKey(lb => lb.Id);
            entity.Property(lb => lb.Name).IsRequired().HasMaxLength(200);
            entity.Property(lb => lb.Address).IsRequired().HasMaxLength(500);
            entity.Property(lb => lb.City).IsRequired().HasMaxLength(100);
            entity.Property(lb => lb.PostalCode).HasMaxLength(20);
            entity.Property(lb => lb.Phone).IsRequired().HasMaxLength(20);
            entity.Property(lb => lb.Email).HasMaxLength(200);
            entity.Property(lb => lb.Description).HasMaxLength(1000);
            entity.HasIndex(lb => lb.Name).IsUnique();
        });

        // BookReview
        modelBuilder.Entity<BookReview>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Title).HasMaxLength(200);
            entity.Property(r => r.Comment).HasMaxLength(2000);

            entity.HasOne(r => r.Book)
                .WithMany(b => b.BookReviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Customer)
                .WithMany(c => c.BookReviews)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(r => new { r.BookId, r.CustomerId }).IsUnique();
        });

        // Notification
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Title).IsRequired().HasMaxLength(200);
            entity.Property(n => n.Message).IsRequired().HasMaxLength(2000);
            entity.HasIndex(n => new { n.CustomerId, n.IsRead });

            entity.HasOne(n => n.Customer)
                .WithMany(c => c.Notifications)
                .HasForeignKey(n => n.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // AuditLog
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.EntityName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Action).IsRequired().HasMaxLength(50);
            entity.Property(a => a.UserId).HasMaxLength(100);
            entity.Property(a => a.UserName).HasMaxLength(200);
            entity.Property(a => a.IpAddress).HasMaxLength(50);
            entity.HasIndex(a => new { a.EntityName, a.EntityId });
            entity.HasIndex(a => a.Timestamp);
        });
    }
}
using Library.Application.Email;
using Library.Application.Interfaces;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Library.Infrastructure.Email;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                    sqlOptions.CommandTimeout(30);
                    sqlOptions.MigrationsAssembly(typeof(LibraryDbContext).Assembly.FullName);
                }));

        // Repositories
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IBookLoanRepository, BookLoanRepository>();
        services.AddScoped<IBookReservationRepository, BookReservationRepository>();
        services.AddScoped<IFineRepository, FineRepository>();
        services.AddScoped<ILibraryBranchRepository, LibraryBranchRepository>();
        services.AddScoped<IBookReviewRepository, BookReviewRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IAuditLogRepository, AuditLogRepository>();

        return services;
    }
}
using System.Net;
using System.Net.Mail;
using Library.Application.Email;
using Library.Application.Interfaces;

namespace Library.Infrastructure.Email;

public class SmtpEmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public SmtpEmailService(EmailSettings settings)
    {
        _settings = settings;
    }

    public async Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)
    {
        using var message = new MailMessage(_settings.From, to, subject, body)
        {
            IsBodyHtml = isHtml
        };

        using var client = new SmtpClient(_settings.Host, _settings.Port)
        {
            EnableSsl = _settings.EnableSsl,
            Credentials = new NetworkCredential(_settings.Username, _settings.Password)
        };

        await client.SendMailAsync(message, cancellationToken);
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class AuditLogRepository : BaseRepository<AuditLog>, IAuditLogRepository
{
    public AuditLogRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityName, Guid entityId)
    {
        return await _dbSet
            .Where(a => a.EntityName == entityName && a.EntityId == entityId)
            .OrderByDescending(a => a.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetByUserAsync(string userId)
    {
        return await _dbSet
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Where(a => a.Timestamp >= startDate && a.Timestamp <= endDate)
            .OrderByDescending(a => a.Timestamp)
            .ToListAsync();
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<Author>> SearchAsync(string searchTerm)
    {
        return await _dbSet
            .Where(a => a.FirstName.Contains(searchTerm)
                || a.LastName.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task<Author?> GetWithBooksAsync(Guid id)
    {
        return await _dbSet
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
using System.Linq.Expressions;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly LibraryDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(LibraryDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
    {
        var totalCount = await _dbSet.CountAsync();
        var items = await _dbSet
            .OrderByDescending(e => e.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }

    public virtual async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.CountAsync(predicate);
    }

    public virtual async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbSet.AnyAsync(e => e.Id == id);
    }

    public virtual async Task AddAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookCategoryRepository : BaseRepository<BookCategory>, IBookCategoryRepository
{
    public BookCategoryRepository(LibraryDbContext context) : base(context) { }

    public async Task<BookCategory?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<BookCategory?> GetWithBooksAsync(Guid id)
    {
        return await _dbSet
            .Include(c => c.Books)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<BookCategory>> GetActiveCategoriesAsync()
    {
        return await _dbSet.Where(c => c.IsActive).ToListAsync();
    }

    public async Task<IEnumerable<BookCategory>> GetRootCategoriesAsync()
    {
        return await _dbSet
            .Where(c => c.ParentCategoryId == null)
            .Include(c => c.SubCategories)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookCategory>> GetSubCategoriesAsync(Guid parentId)
    {
        return await _dbSet
            .Where(c => c.ParentCategoryId == parentId)
            .ToListAsync();
    }
}
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookLoanRepository : BaseRepository<BookLoan>, IBookLoanRepository
{
    public BookLoanRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<BookLoan>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Where(l => l.CustomerId == customerId)
            .OrderByDescending(l => l.LoanDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookLoan>> GetByBookIdAsync(Guid bookId)
    {
        return await _dbSet
            .Include(l => l.Customer)
            .Where(l => l.BookId == bookId)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookLoan>> GetActiveLoansAsync()
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Where(l => l.Status == LoanStatus.Active)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookLoan>> GetOverdueLoansAsync()
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Where(l => l.Status == LoanStatus.Active && l.DueDate < DateTime.UtcNow)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookLoan>> GetByStatusAsync(LoanStatus status)
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Where(l => l.Status == status)
            .ToListAsync();
    }

    public async Task<BookLoan?> GetWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Include(l => l.ProcessedByStaff)
            .Include(l => l.Fines)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<int> GetActiveLoanCountByCustomerAsync(Guid customerId)
    {
        return await _dbSet
            .CountAsync(l => l.CustomerId == customerId && l.Status == LoanStatus.Active);
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
    {
        return await _dbSet
            .Include(b => b.Author)
            .Include(b => b.BookCategory)
            .Where(b => b.IsAvailable)
            .ToListAsync();
    }

    public async Task<Book?> GetByISBNAsync(string isbn)
    {
        return await _dbSet
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.ISBN == isbn);
    }

    public async Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Include(b => b.BookCategory)
            .Where(b => b.AuthorId == authorId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByCategoryIdAsync(Guid categoryId)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Where(b => b.BookCategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByBranchIdAsync(Guid branchId)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Where(b => b.LibraryBranchId == branchId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByPublisherIdAsync(Guid publisherId)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Where(b => b.PublisherId == publisherId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> SearchAsync(string searchTerm)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Include(b => b.BookCategory)
            .Where(b => b.Title.Contains(searchTerm)
                || b.ISBN.Contains(searchTerm)
                || b.Author.FirstName.Contains(searchTerm)
                || b.Author.LastName.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task<Book?> GetWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategory)
            .Include(b => b.LibraryBranch)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookReservationRepository : BaseRepository<BookReservation>, IBookReservationRepository
{
    public BookReservationRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<BookReservation>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Include(r => r.Book)
            .Where(r => r.CustomerId == customerId)
            .OrderByDescending(r => r.ReservationDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReservation>> GetByBookIdAsync(Guid bookId)
    {
        return await _dbSet
            .Include(r => r.Customer)
            .Where(r => r.BookId == bookId)
            .OrderBy(r => r.QueuePosition)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReservation>> GetByStatusAsync(ReservationStatus status)
    {
        return await _dbSet
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .Where(r => r.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReservation>> GetExpiredReservationsAsync()
    {
        return await _dbSet
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .Where(r => r.Status == ReservationStatus.Pending && r.ExpiryDate < DateTime.UtcNow)
            .ToListAsync();
    }

    public async Task<BookReservation?> GetWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookReviewRepository : BaseRepository<BookReview>, IBookReviewRepository
{
    public BookReviewRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<BookReview>> GetByBookIdAsync(Guid bookId)
    {
        return await _dbSet
            .Include(r => r.Customer)
            .Where(r => r.BookId == bookId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReview>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Include(r => r.Book)
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReview>> GetApprovedReviewsByBookAsync(Guid bookId)
    {
        return await _dbSet
            .Include(r => r.Customer)
            .Where(r => r.BookId == bookId && r.IsApproved)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<double> GetAverageRatingByBookAsync(Guid bookId)
    {
        var reviews = await _dbSet
            .Where(r => r.BookId == bookId && r.IsApproved)
            .ToListAsync();

        return reviews.Count != 0 ? reviews.Average(r => r.Rating) : 0;
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(LibraryDbContext context) : base(context) { }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.MembershipNumber == membershipNumber);
    }

    public async Task<IEnumerable<Customer>> GetActiveCustomersAsync()
    {
        return await _dbSet.Where(c => c.IsActive).ToListAsync();
    }

    public async Task<Customer?> GetWithLoansAsync(Guid id)
    {
        return await _dbSet
            .Include(c => c.BookLoans)
                .ThenInclude(l => l.Book)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Customer?> GetWithReservationsAsync(Guid id)
    {
        return await _dbSet
            .Include(c => c.BookReservations)
                .ThenInclude(r => r.Book)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Customer>> SearchAsync(string searchTerm)
    {
        return await _dbSet
            .Where(c => c.FirstName.Contains(searchTerm)
                || c.LastName.Contains(searchTerm)
                || c.Email.Contains(searchTerm)
                || c.MembershipNumber.Contains(searchTerm))
            .ToListAsync();
    }
}
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class FineRepository : BaseRepository<Fine>, IFineRepository
{
    public FineRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<Fine>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Include(f => f.BookLoan)
                .ThenInclude(l => l.Book)
            .Where(f => f.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Fine>> GetByStatusAsync(FineStatus status)
    {
        return await _dbSet
            .Include(f => f.Customer)
            .Where(f => f.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<Fine>> GetPendingFinesAsync()
    {
        return await _dbSet
            .Include(f => f.Customer)
            .Include(f => f.BookLoan)
                .ThenInclude(l => l.Book)
            .Where(f => f.Status == FineStatus.Pending)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalUnpaidFinesByCustomerAsync(Guid customerId)
    {
        return await _dbSet
            .Where(f => f.CustomerId == customerId && f.Status == FineStatus.Pending)
            .SumAsync(f => f.Amount);
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class LibraryBranchRepository : BaseRepository<LibraryBranch>, ILibraryBranchRepository
{
    public LibraryBranchRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<LibraryBranch>> GetActiveBranchesAsync()
    {
        return await _dbSet.Where(lb => lb.IsActive).ToListAsync();
    }

    public async Task<LibraryBranch?> GetWithStaffAsync(Guid id)
    {
        return await _dbSet
            .Include(lb => lb.Staff)
            .FirstOrDefaultAsync(lb => lb.Id == id);
    }

    public async Task<LibraryBranch?> GetWithBooksAsync(Guid id)
    {
        return await _dbSet
            .Include(lb => lb.Books)
            .FirstOrDefaultAsync(lb => lb.Id == id);
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<Notification>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Where(n => n.CustomerId == customerId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Notification>> GetUnreadByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Where(n => n.CustomerId == customerId && !n.IsRead)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task<int> GetUnreadCountByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .CountAsync(n => n.CustomerId == customerId && !n.IsRead);
    }

    public async Task MarkAsReadAsync(Guid id)
    {
        var notification = await _dbSet.FindAsync(id);
        if (notification is not null)
        {
            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task MarkAllAsReadAsync(Guid customerId)
    {
        var unread = await _dbSet
            .Where(n => n.CustomerId == customerId && !n.IsRead)
            .ToListAsync();

        foreach (var notification in unread)
        {
            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(LibraryDbContext context) : base(context) { }

    public async Task<Publisher?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<Publisher?> GetWithBooksAsync(Guid id)
    {
        return await _dbSet
            .Include(p => p.Books)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Publisher>> GetActivePublishersAsync()
    {
        return await _dbSet.Where(p => p.IsActive).ToListAsync();
    }
}
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class StaffRepository : BaseRepository<Staff>, IStaffRepository
{
    public StaffRepository(LibraryDbContext context) : base(context) { }

    public async Task<Staff?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.Email == email);
    }

    public async Task<IEnumerable<Staff>> GetActiveStaffAsync()
    {
        return await _dbSet.Where(s => s.IsActive).ToListAsync();
    }

    public async Task<IEnumerable<Staff>> GetByBranchIdAsync(Guid branchId)
    {
        return await _dbSet
            .Include(s => s.LibraryBranch)
            .Where(s => s.LibraryBranchId == branchId)
            .ToListAsync();
    }

    public async Task<Staff?> GetByEmployeeNumberAsync(string employeeNumber)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.EmployeeNumber == employeeNumber);
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AuthorDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
    {
        var authors = await _authorService.GetAllAsync();
        return Ok(authors);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuthorDto>> GetById(Guid id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author is null)
            return NotFound();

        return Ok(author);
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<AuthorDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> Search([FromQuery] string term)
    {
        var authors = await _authorService.SearchAsync(term);
        return Ok(authors);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<AuthorDto>> Create([FromBody] CreateAuthorDto createDto)
    {
        var author = await _authorService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto updateDto)
    {
        await _authorService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _authorService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BookCategoriesController : ControllerBase
{
    private readonly IBookCategoryService _categoryService;

    public BookCategoriesController(IBookCategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookCategoryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BookCategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookCategoryDto>> GetById(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookCategoryDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BookCategoryDto>> Create([FromBody] CreateBookCategoryDto createDto)
    {
        var category = await _categoryService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookCategoryDto updateDto)
    {
        await _categoryService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BookLoansController : ControllerBase
{
    private readonly IBookLoanService _loanService;

    public BookLoansController(IBookLoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetAll()
    {
        var loans = await _loanService.GetAllAsync();
        return Ok(loans);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BookLoanDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookLoanDto>> GetById(Guid id)
    {
        var loan = await _loanService.GetByIdAsync(id);
        if (loan is null)
            return NotFound();

        return Ok(loan);
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetByCustomer(Guid customerId)
    {
        var loans = await _loanService.GetByCustomerIdAsync(customerId);
        return Ok(loans);
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetActive()
    {
        var loans = await _loanService.GetActiveLoansAsync();
        return Ok(loans);
    }

    [HttpGet("overdue")]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetOverdue()
    {
        var loans = await _loanService.GetOverdueLoansAsync();
        return Ok(loans);
    }

    [HttpGet("status/{status}")]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetByStatus(LoanStatus status)
    {
        var loans = await _loanService.GetByStatusAsync(status);
        return Ok(loans);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookLoanDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookLoanDto>> Create([FromBody] CreateBookLoanDto createDto)
    {
        var loan = await _loanService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
    }

    [HttpPost("{id:guid}/return")]
    [ProducesResponseType(typeof(BookLoanDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookLoanDto>> ReturnBook(Guid id, [FromBody] ReturnBookLoanDto returnDto)
    {
        var loan = await _loanService.ReturnBookAsync(id, returnDto);
        return Ok(loan);
    }

    [HttpPost("{id:guid}/renew")]
    [ProducesResponseType(typeof(BookLoanDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookLoanDto>> RenewLoan(Guid id, [FromBody] RenewBookLoanDto renewDto)
    {
        var loan = await _loanService.RenewLoanAsync(id, renewDto);
        return Ok(loan);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _loanService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BookReservationsController : ControllerBase
{
    private readonly IBookReservationService _reservationService;

    public BookReservationsController(IBookReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookReservationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetAll()
    {
        var reservations = await _reservationService.GetAllAsync();
        return Ok(reservations);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BookReservationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookReservationDto>> GetById(Guid id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        if (reservation is null)
            return NotFound();

        return Ok(reservation);
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookReservationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetByCustomer(Guid customerId)
    {
        var reservations = await _reservationService.GetByCustomerIdAsync(customerId);
        return Ok(reservations);
    }

    [HttpGet("book/{bookId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookReservationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetByBook(Guid bookId)
    {
        var reservations = await _reservationService.GetByBookIdAsync(bookId);
        return Ok(reservations);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookReservationDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookReservationDto>> Create([FromBody] CreateBookReservationDto createDto)
    {
        var reservation = await _reservationService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
    }

    [HttpPost("{id:guid}/cancel")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await _reservationService.CancelReservationAsync(id);
        return NoContent();
    }

    [HttpPost("{id:guid}/fulfill")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Fulfill(Guid id)
    {
        await _reservationService.FulfillReservationAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _reservationService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BookReviewsController : ControllerBase
{
    private readonly IBookReviewService _reviewService;

    public BookReviewsController(IBookReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("book/{bookId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookReviewDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReviewDto>>> GetByBook(Guid bookId)
    {
        var reviews = await _reviewService.GetByBookIdAsync(bookId);
        return Ok(reviews);
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookReviewDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReviewDto>>> GetByCustomer(Guid customerId)
    {
        var reviews = await _reviewService.GetByCustomerIdAsync(customerId);
        return Ok(reviews);
    }

    [HttpGet("book/{bookId:guid}/average-rating")]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    public async Task<ActionResult<double>> GetAverageRating(Guid bookId)
    {
        var rating = await _reviewService.GetAverageRatingAsync(bookId);
        return Ok(rating);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BookReviewDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookReviewDto>> GetById(Guid id)
    {
        var review = await _reviewService.GetByIdAsync(id);
        if (review is null)
            return NotFound();

        return Ok(review);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookReviewDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BookReviewDto>> Create([FromBody] CreateBookReviewDto createDto)
    {
        var review = await _reviewService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = review.Id }, review);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookReviewDto updateDto)
    {
        await _reviewService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpPost("{id:guid}/approve")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Approve(Guid id)
    {
        await _reviewService.ApproveReviewAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _reviewService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookDto>> GetById(Guid id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book is null)
            return NotFound();

        return Ok(book);
    }

    [HttpGet("available")]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()
    {
        var books = await _bookService.GetAvailableBooksAsync();
        return Ok(books);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)
    {
        var book = await _bookService.CreateAsync(createBookDto);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)
    {
        await _bookService.UpdateAsync(id, updateBookDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CustomerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerDto>> GetById(Guid id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer is null)
            return NotFound();

        return Ok(customer);
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<CustomerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()
    {
        var customers = await _customerService.GetActiveCustomersAsync();
        return Ok(customers);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)
    {
        var customer = await _customerService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)
    {
        await _customerService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _customerService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("stats")]
    [ProducesResponseType(typeof(DashboardStatsDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<DashboardStatsDto>> GetStats()
    {
        var stats = await _dashboardService.GetStatsAsync();
        return Ok(stats);
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class FinesController : ControllerBase
{
    private readonly IFineService _fineService;

    public FinesController(IFineService fineService)
    {
        _fineService = fineService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FineDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FineDto>>> GetAll()
    {
        var fines = await _fineService.GetAllAsync();
        return Ok(fines);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FineDto>> GetById(Guid id)
    {
        var fine = await _fineService.GetByIdAsync(id);
        if (fine is null)
            return NotFound();

        return Ok(fine);
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<FineDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FineDto>>> GetByCustomer(Guid customerId)
    {
        var fines = await _fineService.GetByCustomerIdAsync(customerId);
        return Ok(fines);
    }

    [HttpGet("customer/{customerId:guid}/total-unpaid")]
    [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
    public async Task<ActionResult<decimal>> GetTotalUnpaid(Guid customerId)
    {
        var total = await _fineService.GetTotalUnpaidByCustomerAsync(customerId);
        return Ok(total);
    }

    [HttpGet("pending")]
    [ProducesResponseType(typeof(IEnumerable<FineDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FineDto>>> GetPending()
    {
        var fines = await _fineService.GetPendingFinesAsync();
        return Ok(fines);
    }

    [HttpPost]
    [ProducesResponseType(typeof(FineDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<FineDto>> Create([FromBody] CreateFineDto createDto)
    {
        var fine = await _fineService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = fine.Id }, fine);
    }

    [HttpPost("{id:guid}/pay")]
    [ProducesResponseType(typeof(FineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FineDto>> PayFine(Guid id, [FromBody] PayFineDto payDto)
    {
        var fine = await _fineService.PayFineAsync(id, payDto);
        return Ok(fine);
    }

    [HttpPost("{id:guid}/waive")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> WaiveFine(Guid id)
    {
        await _fineService.WaiveFineAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _fineService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class LibraryBranchesController : ControllerBase
{
    private readonly ILibraryBranchService _branchService;

    public LibraryBranchesController(ILibraryBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LibraryBranchDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LibraryBranchDto>>> GetAll()
    {
        var branches = await _branchService.GetAllAsync();
        return Ok(branches);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(LibraryBranchDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LibraryBranchDto>> GetById(Guid id)
    {
        var branch = await _branchService.GetByIdAsync(id);
        if (branch is null)
            return NotFound();

        return Ok(branch);
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<LibraryBranchDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LibraryBranchDto>>> GetActive()
    {
        var branches = await _branchService.GetActiveBranchesAsync();
        return Ok(branches);
    }

    [HttpPost]
    [ProducesResponseType(typeof(LibraryBranchDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<LibraryBranchDto>> Create([FromBody] CreateLibraryBranchDto createDto)
    {
        var branch = await _branchService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = branch.Id }, branch);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLibraryBranchDto updateDto)
    {
        await _branchService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _branchService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<NotificationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetByCustomer(Guid customerId)
    {
        var notifications = await _notificationService.GetByCustomerIdAsync(customerId);
        return Ok(notifications);
    }

    [HttpGet("customer/{customerId:guid}/unread")]
    [ProducesResponseType(typeof(IEnumerable<NotificationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetUnread(Guid customerId)
    {
        var notifications = await _notificationService.GetUnreadByCustomerIdAsync(customerId);
        return Ok(notifications);
    }

    [HttpGet("customer/{customerId:guid}/unread-count")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<ActionResult<int>> GetUnreadCount(Guid customerId)
    {
        var count = await _notificationService.GetUnreadCountAsync(customerId);
        return Ok(count);
    }

    [HttpPost]
    [ProducesResponseType(typeof(NotificationDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<NotificationDto>> Create([FromBody] CreateNotificationDto createDto)
    {
        var notification = await _notificationService.CreateAsync(createDto);
        return Created(string.Empty, notification);
    }

    [HttpPost("{id:guid}/read")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> MarkAsRead(Guid id)
    {
        await _notificationService.MarkAsReadAsync(id);
        return NoContent();
    }

    [HttpPost("customer/{customerId:guid}/read-all")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> MarkAllAsRead(Guid customerId)
    {
        await _notificationService.MarkAllAsReadAsync(customerId);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _notificationService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PublishersController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PublisherDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PublisherDto>>> GetAll()
    {
        var publishers = await _publisherService.GetAllAsync();
        return Ok(publishers);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PublisherDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PublisherDto>> GetById(Guid id)
    {
        var publisher = await _publisherService.GetByIdAsync(id);
        if (publisher is null)
            return NotFound();

        return Ok(publisher);
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<PublisherDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PublisherDto>>> GetActive()
    {
        var publishers = await _publisherService.GetActivePublishersAsync();
        return Ok(publishers);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PublisherDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<PublisherDto>> Create([FromBody] CreatePublisherDto createDto)
    {
        var publisher = await _publisherService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = publisher.Id }, publisher);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePublisherDto updateDto)
    {
        await _publisherService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _publisherService.DeleteAsync(id);
        return NoContent();
    }
}
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class StaffController : ControllerBase
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StaffDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()
    {
        var staffList = await _staffService.GetAllAsync();
        return Ok(staffList);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(StaffDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StaffDto>> GetById(Guid id)
    {
        var staff = await _staffService.GetByIdAsync(id);
        if (staff is null)
            return NotFound();

        return Ok(staff);
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<StaffDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StaffDto>>> GetActive()
    {
        var staffList = await _staffService.GetActiveStaffAsync();
        return Ok(staffList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(StaffDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)
    {
        var staff = await _staffService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)
    {
        await _staffService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _staffService.DeleteAsync(id);
        return NoContent();
    }
}
using System.Net;
using System.Text.Json;
using Library.Application.Common.Exceptions;
using Library.Application.Common.Models;

namespace Library.Middleware;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, response) = exception switch
        {
            NotFoundException notFound => (
                HttpStatusCode.NotFound,
                ApiResponse<object>.FailResponse(notFound.Message)
            ),
            BadRequestException badRequest => (
                HttpStatusCode.BadRequest,
                ApiResponse<object>.FailResponse(badRequest.Message, badRequest.Errors)
            ),
            ConflictException conflict => (
                HttpStatusCode.Conflict,
                ApiResponse<object>.FailResponse(conflict.Message)
            ),
            UnauthorizedAccessException => (
                HttpStatusCode.Unauthorized,
                ApiResponse<object>.FailResponse("Unauthorized access.")
            ),
            _ => (
                HttpStatusCode.InternalServerError,
                ApiResponse<object>.FailResponse("An unexpected error occurred.")
            )
        };

        if (statusCode == HttpStatusCode.InternalServerError)
        {
            _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);
        }
        else
        {
            _logger.LogWarning("Handled exception: {ExceptionType} - {Message}", exception.GetType().Name, exception.Message);
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var json = JsonSerializer.Serialize(response, options);
        await context.Response.WriteAsync(json);
    }
}
using System.Diagnostics;

namespace Library.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId = context.Request.Headers["X-Correlation-ID"].FirstOrDefault()
            ?? Guid.NewGuid().ToString();

        context.Items["CorrelationId"] = correlationId;
        context.Response.Headers["X-Correlation-ID"] = correlationId;

        var stopwatch = Stopwatch.StartNew();

        _logger.LogInformation(
            "HTTP {Method} {Path} started | CorrelationId: {CorrelationId}",
            context.Request.Method,
            context.Request.Path,
            correlationId);

        await _next(context);

        stopwatch.Stop();

        _logger.LogInformation(
            "HTTP {Method} {Path} completed {StatusCode} in {ElapsedMs}ms | CorrelationId: {CorrelationId}",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds,
            correlationId);
    }
}
using Library.Application;
using Library.Infrastructure;
using Library.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library Management API",
        Version = "v1",
        Description = "Enterprise Library Management System API",
        Contact = new OpenApiContact
        {
            Name = "Library Admin",
            Email = "admin@library.com"
        }
    });
});

// Health Checks
builder.Services.AddHealthChecks();

// Response Caching
builder.Services.AddResponseCaching();

var app = builder.Build();

// Middleware pipeline
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Management API v1");
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
