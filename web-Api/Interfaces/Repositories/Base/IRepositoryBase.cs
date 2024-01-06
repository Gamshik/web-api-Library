using System.Linq.Expressions;

namespace Contracts.Repositories.Base
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition);
        Task UpdateAsync(T entity, Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    }
}
