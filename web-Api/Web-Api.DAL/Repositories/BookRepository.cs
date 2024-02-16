using Contracts.Repositories;
using Entites.Entities;
using Microsoft.EntityFrameworkCore;
using Web_Api.DAL.Context;
using Web_Api.DAL.Repositories.Base;

namespace Web_Api.DAL.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public async Task CreateBookAsync(Book book, CancellationToken cancellationToken = default) => await CreateAsync(book, cancellationToken);
        public IQueryable<Book> FindBookById(int id) => FindByCondition(b => b.Id == id).Include(b => b.Author);
        public IQueryable<Book> GetAllBooks() => GetAll().Include(b => b.Author.FirstName);
        public async Task UpdateBookAsync(Book book, CancellationToken cancellationToken = default) => await UpdateAsync(book, b => b.Id == book.Id, cancellationToken);
        public async Task DeleteBookAsync(int id, CancellationToken cancellationToken = default) => await DeleteAsync(b => b.Id == id, cancellationToken);
    }
}
