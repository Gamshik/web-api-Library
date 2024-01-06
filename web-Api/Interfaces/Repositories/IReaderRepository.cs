using Entites.Entities;

namespace Contracts.Repositories
{
    public interface IReaderRepository
    {
        Task CreateReaderAsync(Reader reader, CancellationToken cancellationToken = default);
        IQueryable<Reader> FindReaderById(int id);
        IQueryable<Reader> GetAllReaders();
        Task UpdateReaderAsync(Reader reader, CancellationToken cancellationToken = default);
        Task DeleteReaderAsync(int id, CancellationToken cancellationToken = default);
    }
}
