using Entites.Entities;

namespace Interfaces.Repositories
{
    public interface IReaderRepository
    {
        Task CreateReaderAsync(Reader reader, CancellationToken cancellationToken);
        Task<IQueryable<Reader>?> GetAllReadersAsync(CancellationToken cancellationToken = default);
        Task<Reader?> FindReaderByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateReaderAsync(Reader reader, CancellationToken cancellationToken = default);
        Task DeleteReaderAsync(int id, CancellationToken cancellationToken = default);
    }
}
