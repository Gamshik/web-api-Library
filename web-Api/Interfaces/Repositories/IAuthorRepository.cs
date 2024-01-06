using Entites.Entities;

namespace Contracts.Repositories
{
    public interface IAuthorRepository
    {
        Task CreateAuthorAsync(Author author, CancellationToken cancellationToken = default);
        IQueryable<Author> FindAuthorById(int id);
        IQueryable<Author> GetAllAuthors();
        Task UpdateAuthorAsync(Author author, CancellationToken cancellationToken = default);
        Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    }
}