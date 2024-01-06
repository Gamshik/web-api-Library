using Entites.DataTransferObjects.IssueDtos;

namespace Contracts.Services
{
    public interface IIssueService
    {
        Task CreateIssueAsync(IssueForCreateDto issueForCreateDto, CancellationToken cancellationToken = default);
        IEnumerable<IssueDto> FindIssueById(int id);
        IEnumerable<IssueDto> GetAllIssues();
        Task UpdateIssueAsync(IssueForUpdateDto issueForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default);
    }
}
