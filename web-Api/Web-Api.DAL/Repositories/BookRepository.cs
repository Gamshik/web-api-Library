using Entites.Entities;
using Entites.Exceptions;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Web_Api.DAL.Context;

namespace Web_Api.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _libraryContext;
        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public async Task CreateBookAsync(Book book, CancellationToken cancellationToken = default)
        {
            await _libraryContext.Books.AddAsync(book, cancellationToken);
            await _libraryContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            var book = await _libraryContext.Books.SingleOrDefaultAsync(b => b.Id == id, cancellationToken);
            if (book == null)
            {
                throw new NotFoundException($"Book with id = {id} not found!");
            }

            _libraryContext.Books.Remove(book);

            await _libraryContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Book?> FindBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _libraryContext.Books.AsNoTracking().Include(b => b.Author).SingleOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        public async Task<IQueryable<Book>?> GetAllBooksAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_libraryContext.Books.AsNoTracking().Include(b => b.Author));
        }

        public async Task UpdateBookAsync(Book book, CancellationToken cancellationToken = default)
        {
            var bookCheck = await _libraryContext.Books.AsNoTracking().SingleOrDefaultAsync(a => a.Id == book.Id, cancellationToken);

            if (bookCheck == null)
            {
                throw new NotFoundException($"Book with id = {book.Id} not found!");
            }

            _libraryContext.Books.Update(book);

            await _libraryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
