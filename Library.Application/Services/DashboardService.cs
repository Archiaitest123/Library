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
