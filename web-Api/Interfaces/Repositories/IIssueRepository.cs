using Entites.Entities;

namespace Contracts.Repositories
{
    public interface IIssueRepository
    {
        Task CreateIssueAsync(Issue issue, CancellationToken cancellationToken = default);
        IQueryable<Issue> FindIssueById(int id);
        IQueryable<Issue> GetAllIssues();
        Task UpdateIssueAsync(Issue issue, CancellationToken cancellationToken = default);
        Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default);
    }
}
