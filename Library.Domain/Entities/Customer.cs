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
