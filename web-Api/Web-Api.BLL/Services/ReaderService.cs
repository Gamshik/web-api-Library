using AutoMapper;
using Entites.DataTransferObjects.ReaderDtos;
using Entites.Entities;
using FluentValidation;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Web_Api.BLL.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IMapper _mapper;
        private readonly IReaderRepository _readerRepository;
        private readonly IValidator<Reader> _readerValidator;
        public ReaderService(IMapper mapper, IReaderRepository readerRepository, IValidator<Reader> readerValidator)
        {
            _mapper = mapper;
            _readerRepository = readerRepository;
            _readerValidator = readerValidator;
        }
        public async Task CreateReaderAsync(ReaderForCreateDto readerForCreateDto, CancellationToken cancellationToken = default)
        {
            var reader = _mapper.Map<Reader>(readerForCreateDto);

            await _readerValidator.ValidateAndThrowAsync(reader, cancellationToken);

            await _readerRepository.CreateReaderAsync(reader, cancellationToken);
        }

        public async Task DeleteReaderAsync(int id, CancellationToken cancellationToken = default)
        {
            await _readerRepository.DeleteReaderAsync(id, cancellationToken);
        }

        public async Task<ReaderDto?> FindReaderByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<ReaderDto>(await _readerRepository.FindReaderByIdAsync(id, cancellationToken));
        }

        public async Task<IEnumerable<ReaderDto>?> GetAllReadersAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<ReaderDto>>(await _readerRepository.GetAllReadersAsync(cancellationToken));
        }

        public async Task UpdateReaderAsync(ReaderForUpdateDto readerForUpdateDto, CancellationToken cancellationToken = default)
        {
            var reader = _mapper.Map<Reader>(readerForUpdateDto);

            await _readerValidator.ValidateAndThrowAsync(reader, cancellationToken);

            await _readerRepository.UpdateReaderAsync(reader, cancellationToken);
        }
    }
}
