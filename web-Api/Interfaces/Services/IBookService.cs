using Entites.DataTransferObjects.BookDtos;

namespace Contracts.Services
{
    public interface IBookService
    {
        Task CreateBookAsync(BookForCreateDto bookForCreateDto, CancellationToken cancellationToken = default);
        IEnumerable<BookDto> FindBookById(int id);
        IEnumerable<BookDto> GetAllBooks();
        Task UpdateBookAsync(BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}
