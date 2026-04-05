using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IMembershipSummaryService
{
    Task<MembershipSummaryDto> GetSummaryAsync(Guid customerId);
}
