using Entites.Entities;

namespace Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task CreateBookAsync(Book book, CancellationToken cancellationToken = default);
        Task<IQueryable<Book>?> GetAllBooksAsync(CancellationToken cancellationToken = default);
        Task<Book?> FindBookByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateBookAsync(Book book, CancellationToken cancellationToken = default);
        Task DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}
