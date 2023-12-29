using Entites.DataTransferObjects.BookDtos;

namespace Interfaces.Services
{
    public interface IBookService
    {
        Task CreateBookAsync(BookForCreateDto bookForCreateDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<BookDto>?> GetAllBooksAsync(CancellationToken cancellationToken = default);
        Task<BookDto?> FindBookByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateBookAsync(BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}
