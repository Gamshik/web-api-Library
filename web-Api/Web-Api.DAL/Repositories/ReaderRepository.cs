using Entites.Entities;
using Entites.Exceptions;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Web_Api.DAL.Context;

namespace Web_Api.DAL.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryContext _libraryContext;
        public ReaderRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public async Task CreateReaderAsync(Reader reader, CancellationToken cancellationToken)
        {
            await _libraryContext.Readers.AddAsync(reader, cancellationToken);
            await _libraryContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteReaderAsync(int id, CancellationToken cancellationToken = default)
        {
            var reader = await _libraryContext.Readers.SingleOrDefaultAsync(r => r.Id == id, cancellationToken);

            if (reader == null)
            {
                throw new NotFoundException($"Reader with id = {id} not found!");
            }

            _libraryContext.Readers.Remove(reader);

            await _libraryContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Reader?> FindReaderByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _libraryContext.Readers.AsNoTracking().SingleOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<IQueryable<Reader>?> GetAllReadersAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_libraryContext.Readers.AsNoTracking());
        }

        public async Task UpdateReaderAsync(Reader reader, CancellationToken cancellationToken = default)
        {
            var readerCheck = await _libraryContext.Readers.AsNoTracking().SingleOrDefaultAsync(a => a.Id == reader.Id, cancellationToken);

            if (readerCheck == null)
            {
                throw new NotFoundException($"Issue with id = {reader.Id} not found!");
            }

            _libraryContext.Readers.Update(reader);

            await _libraryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
