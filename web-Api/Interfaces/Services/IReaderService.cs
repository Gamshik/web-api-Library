using Entites.DataTransferObjects.ReaderDtos;

namespace Interfaces.Services
{
    public interface IReaderService
    {
        Task CreateReaderAsync(ReaderForCreateDto readerForCreateDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReaderDto>?> GetAllReadersAsync(CancellationToken cancellationToken = default);
        Task<ReaderDto?> FindReaderByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateReaderAsync(ReaderForUpdateDto readerForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteReaderAsync(int id, CancellationToken cancellationToken = default);
    }
}
