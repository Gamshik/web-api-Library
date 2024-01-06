using Contracts.Repositories.Base;
using Entites.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web_Api.DAL.Context;

namespace Web_Api.DAL.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly LibraryContext _libraryContext;

        public RepositoryBase(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _libraryContext.Set<T>().AddAsync(entity, cancellationToken);
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition)
        {
            return _libraryContext.Set<T>().AsNoTracking().Where(condition);
        }
        public IQueryable<T> GetAll()
        {
            return _libraryContext.Set<T>().AsNoTracking();
        }
        public async Task UpdateAsync(T entity, Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            var searchedEntity = await SearchEntityAsync(expression, cancellationToken);

            if (searchedEntity == null)
            {
                throw new NotFoundException("User for update has not been searched!");
            }

            _libraryContext.Set<T>().Update(entity);
        }
        public async Task DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            var searchedEntity = await SearchEntityAsync(expression, cancellationToken);

            if (searchedEntity == null)
            {
                throw new NotFoundException("User for delete has not been searched!");
            }

            _libraryContext.Set<T>().Remove(searchedEntity);
        }
        private async Task<T?> SearchEntityAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _libraryContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression, cancellationToken);
        }
    }
}
