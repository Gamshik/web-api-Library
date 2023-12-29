using Entites.DataTransferObjects.IssueDtos;

namespace Interfaces.Services
{
    public interface IIssueService
    {
        Task CreateIssueAsync(IssueForCreateDto issueForCreateDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<IssueDto>?> GetAllIssuesAsync(CancellationToken cancellationToken = default);
        Task<IssueDto?> FindIssueByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateIssueAsync(IssueForUpdateDto issueForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default);
    }
}
