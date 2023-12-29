using Entites.Entities;
using Entites.Exceptions;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Web_Api.DAL.Context;

namespace Web_Api.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _libraryContext;
        public AuthorRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public async Task CreateAuthorAsync(Author author, CancellationToken cancellationToken = default)
        {
            await _libraryContext.Authors.AddAsync(author);
            await _libraryContext.SaveChangesAsync();
        }
        public async Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
        {
            var author = await _libraryContext.Authors.SingleOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (author == null)
            {
                throw new NotFoundException($"Author with id = {id} not found!");
            }

            _libraryContext.Authors.Remove(author);

            await _libraryContext.SaveChangesAsync();
        }

        public async Task<Author?> FindAuthorByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _libraryContext.Authors.AsNoTracking().SingleOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<IQueryable<Author>?> GetAllAuthorsAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_libraryContext.Authors.AsNoTracking().OrderBy(a => a.FirstName));
        }

        public async Task UpdateAuthorAsync(Author author, CancellationToken cancellationToken = default)
        {
            var authorCheck = await _libraryContext.Authors.AsNoTracking().SingleOrDefaultAsync(a => a.Id == author.Id, cancellationToken);

            if (authorCheck == null)
            {
                throw new NotFoundException($"Author with id = {author.Id} not found!");
            }

            _libraryContext.Authors.Update(author);

            await _libraryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
