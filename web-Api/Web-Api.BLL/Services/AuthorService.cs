using AutoMapper;
using Entites.DataTransferObjects.AuthorDtos;
using Entites.Entities;
using FluentValidation;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Web_Api.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IValidator<Author> _authorValidator;
        public AuthorService(IMapper mapper, IAuthorRepository authorRepository, IValidator<Author> authorValidator)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _authorValidator = authorValidator;
        }
        public async Task CreateAuthorAsync(AuthorForCreateDto authorForCreateDto, CancellationToken cancellationToken = default)
        {
            var author = _mapper.Map<Author>(authorForCreateDto);

            await _authorValidator.ValidateAndThrowAsync(author, cancellationToken);

            await _authorRepository.CreateAuthorAsync(author, cancellationToken);
        }

        public async Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
        {
            await _authorRepository.DeleteAuthorAsync(id, cancellationToken);
        }

        public async Task<AuthorDto?> FindAuthorByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<AuthorDto>(await _authorRepository.FindAuthorByIdAsync(id, cancellationToken));
        }

        public async Task<IEnumerable<AuthorDto>?> GetAllAuthorAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<AuthorDto>>(await _authorRepository.GetAllAuthorsAsync(cancellationToken));
        }

        public async Task UpdateAuthorAsync(AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken = default)
        {
            var author = _mapper.Map<Author>(authorForUpdateDto);

            await _authorValidator.ValidateAndThrowAsync(author, cancellationToken);

            await _authorRepository.UpdateAuthorAsync(author, cancellationToken);
        }
    }
}