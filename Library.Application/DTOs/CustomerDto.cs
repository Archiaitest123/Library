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
