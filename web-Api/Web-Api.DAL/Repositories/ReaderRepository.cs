using Contracts.Repositories;
using Entites.Entities;
using Web_Api.DAL.Context;
using Web_Api.DAL.Repositories.Base;

namespace Web_Api.DAL.Repositories
{
    public class ReaderRepository : RepositoryBase<Reader>, IReaderRepository
    {
        public ReaderRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public async Task CreateReaderAsync(Reader reader, CancellationToken cancellationToken = default) => await CreateAsync(reader, cancellationToken);
        public IQueryable<Reader> FindReaderById(int id) => FindByCondition(r => r.Id == id);
        public IQueryable<Reader> GetAllReaders() => GetAll();
        public async Task UpdateReaderAsync(Reader reader, CancellationToken cancellationToken = default) => await UpdateAsync(reader, r => r.Id == reader.Id, cancellationToken);
        public async Task DeleteReaderAsync(int id, CancellationToken cancellationToken = default) => await DeleteAsync(r => r.Id == id, cancellationToken);
    }
}
