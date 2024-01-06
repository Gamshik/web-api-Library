using Contracts.Repositories;

namespace Contracts.Managers
{
    public interface IRepositoryManager
    {
        IAuthorRepository Author { get; }
        IBookRepository Book { get; }
        IIssueRepository Issue { get; }
        IReaderRepository Reader { get; }
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
