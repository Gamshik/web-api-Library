using AutoMapper;
using Contracts.Managers;
using Contracts.Services;
using Entites.DataTransferObjects.AuthorDtos;
using Entites.Entities;
using FluentValidation;

namespace Web_Api.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IValidator<Author> _authorValidator;

        public AuthorService(IMapper mapper, IRepositoryManager repositoryManager, IValidator<Author> authorValidator)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _authorValidator = authorValidator;
        }

        public async Task CreateAuthorAsync(AuthorForCreateDto authorForCreateDto, CancellationToken cancellationToken = default)
        {
            var author = _mapper.Map<Author>(authorForCreateDto);

            await _authorValidator.ValidateAndThrowAsync(author, cancellationToken);

            await _repositoryManager.Author.CreateAuthorAsync(author);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
        public IEnumerable<AuthorDto> FindAuthorById(int id)
        {
            return _mapper.Map<IEnumerable<AuthorDto>?>(_repositoryManager.Author.FindAuthorById(id));
        }

        public IEnumerable<AuthorDto> GetAllAuthor()
        {
            return _mapper.Map<IEnumerable<AuthorDto>>(_repositoryManager.Author.GetAllAuthors());
        }
        public async Task UpdateAuthorAsync(AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken = default)
        {
            var author = _mapper.Map<Author>(authorForUpdateDto);

            await _authorValidator.ValidateAndThrowAsync(author, cancellationToken);

            await _repositoryManager.Author.UpdateAuthorAsync(author, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
        public async Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
        {
            await _repositoryManager.Author.DeleteAuthorAsync(id, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
    }
}