using Entites.Entities;

namespace Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task CreateAuthorAsync(Author author, CancellationToken cancellationToken = default);
        Task<IQueryable<Author>?> GetAllAuthorsAsync(CancellationToken cancellationToken = default);
        Task<Author?> FindAuthorByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAuthorAsync(Author author, CancellationToken cancellationToken = default);
        Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    }
}
