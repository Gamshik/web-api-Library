using AutoMapper;
using Contracts.Managers;
using Contracts.Services;
using Entites.DataTransferObjects.ReaderDtos;
using Entites.Entities;
using FluentValidation;

namespace Web_Api.BLL.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IValidator<Reader> _readerValidator;

        public ReaderService(IMapper mapper, IRepositoryManager repositoryManager, IValidator<Reader> readerValidator)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _readerValidator = readerValidator;
        }

        public async Task CreateReaderAsync(ReaderForCreateDto readerForCreateDto, CancellationToken cancellationToken = default)
        {
            var reader = _mapper.Map<Reader>(readerForCreateDto);

            await _readerValidator.ValidateAndThrowAsync(reader, cancellationToken);

            await _repositoryManager.Reader.CreateReaderAsync(reader, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
        public IEnumerable<ReaderDto> FindReaderById(int id)
        {
            return _mapper.Map<IEnumerable<ReaderDto>>(_repositoryManager.Reader.FindReaderById(id));
        }
        public IEnumerable<ReaderDto> GetAllReaders()
        {
            return _mapper.Map<IEnumerable<ReaderDto>>(_repositoryManager.Reader.GetAllReaders());
        }
        public async Task UpdateReaderAsync(ReaderForUpdateDto readerForUpdateDto, CancellationToken cancellationToken = default)
        {
            var reader = _mapper.Map<Reader>(readerForUpdateDto);

            await _readerValidator.ValidateAndThrowAsync(reader, cancellationToken);

            await _repositoryManager.Reader.UpdateReaderAsync(reader, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
        public async Task DeleteReaderAsync(int id, CancellationToken cancellationToken = default)
        {
            await _repositoryManager.Reader.DeleteReaderAsync(id, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
    }
}
