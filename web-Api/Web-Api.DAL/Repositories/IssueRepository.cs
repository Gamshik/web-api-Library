using Entites.Entities;
using Entites.Exceptions;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Web_Api.DAL.Context;

namespace Web_Api.DAL.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly LibraryContext _libraryContext;
        public IssueRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public async Task CreateIssueAsync(Issue issue, CancellationToken cancellationToken)
        {
            await _libraryContext.Issues.AddAsync(issue, cancellationToken);
            await _libraryContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default)
        {
            var issue = await _libraryContext.Issues.SingleOrDefaultAsync(i => i.Id == id, cancellationToken);

            if (issue == null)
            {
                throw new NotFoundException($"Issue with id = {id} not found!");
            }

            _libraryContext.Issues.Remove(issue);

            await _libraryContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Issue?> FindIssueByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _libraryContext.Issues.AsNoTracking().Include(i => i.Book).ThenInclude(b => b.Author).Include(i => i.Reader).SingleOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<IQueryable<Issue>?> GetAllIssuesAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_libraryContext.Issues.AsNoTracking().Include(i => i.Book).ThenInclude(b => b.Author).Include(i => i.Reader));
        }

        public async Task UpdateIssueAsync(Issue issue, CancellationToken cancellationToken = default)
        {
            var issueCheck = await _libraryContext.Issues.AsNoTracking().SingleOrDefaultAsync(a => a.Id == issue.Id, cancellationToken);

            if (issueCheck == null)
            {
                throw new NotFoundException($"Issue with id = {issue.Id} not found!");
            }

            _libraryContext.Issues.Update(issue);

            await _libraryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
