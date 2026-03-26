namespace Library.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string MembershipNumber { get; set; } = string.Empty;
    public DateTime RegisteredDate { get; set; }
    public bool IsActive { get; set; } = true;
}
