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
