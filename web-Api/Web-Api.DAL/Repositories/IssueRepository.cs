using Contracts.Repositories;
using Entites.Entities;
using Microsoft.EntityFrameworkCore;
using Web_Api.DAL.Context;
using Web_Api.DAL.Repositories.Base;

namespace Web_Api.DAL.Repositories
{
    public class IssueRepository : RepositoryBase<Issue>, IIssueRepository
    {
        public IssueRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public async Task CreateIssueAsync(Issue issue, CancellationToken cancellationToken = default) => await CreateAsync(issue, cancellationToken);
        public IQueryable<Issue> FindIssueById(int id) => FindByCondition(i => i.Id == id).Include(i => i.Book).ThenInclude(b => b.Author).Include(i => i.Reader);
        public IQueryable<Issue> GetAllIssues() => GetAll().Include(i => i.Book).ThenInclude(b => b.Author).Include(i => i.Reader);
        public async Task UpdateIssueAsync(Issue issue, CancellationToken cancellationToken = default) => await UpdateAsync(issue, i => i.Id == issue.Id, cancellationToken);
        public async Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default) => await DeleteAsync(i => i.Id == id, cancellationToken);
    }
}
