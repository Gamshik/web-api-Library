using Entites.DataTransferObjects.ReaderDtos;

namespace Contracts.Services
{
    public interface IReaderService
    {
        Task CreateReaderAsync(ReaderForCreateDto readerForCreateDto, CancellationToken cancellationToken = default);
        IEnumerable<ReaderDto> FindReaderById(int id);
        IEnumerable<ReaderDto> GetAllReaders();
        Task UpdateReaderAsync(ReaderForUpdateDto readerForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteReaderAsync(int id, CancellationToken cancellationToken = default);
    }
}
