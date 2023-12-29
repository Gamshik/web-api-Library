using Entites.Entities;

namespace Interfaces.Repositories
{
    public interface IIssueRepository
    {
        Task CreateIssueAsync(Issue issue, CancellationToken cancellationToken);
        Task<IQueryable<Issue>?> GetAllIssuesAsync(CancellationToken cancellationToken = default);
        Task<Issue?> FindIssueByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateIssueAsync(Issue issue, CancellationToken cancellationToken = default);
        Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default);
    }
}
