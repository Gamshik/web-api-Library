using Entites.Entities;

namespace Contracts.Repositories
{
    public interface IBookRepository
    {
        Task CreateBookAsync(Book book, CancellationToken cancellationToken = default);
        IQueryable<Book> FindBookById(int id);
        IQueryable<Book> GetAllBooks();
        Task UpdateBookAsync(Book book, CancellationToken cancellationToken = default);
        Task DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}