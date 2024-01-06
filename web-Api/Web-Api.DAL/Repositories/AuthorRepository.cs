using Contracts.Repositories;
using Entites.Entities;
using Web_Api.DAL.Context;
using Web_Api.DAL.Repositories.Base;

namespace Web_Api.DAL.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public async Task CreateAuthorAsync(Author author, CancellationToken cancellationToken = default) => await CreateAsync(author, cancellationToken);
        public IQueryable<Author> FindAuthorById(int id) => FindByCondition(a => a.Id == id);
        public IQueryable<Author> GetAllAuthors() => GetAll();
        public async Task UpdateAuthorAsync(Author author, CancellationToken cancellationToken = default) => await UpdateAsync(author, a => a.Id == author.Id, cancellationToken);
        public async Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default) => await DeleteAsync(a => a.Id == id, cancellationToken);
    }
}
