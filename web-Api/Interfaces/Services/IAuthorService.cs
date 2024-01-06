using Entites.DataTransferObjects.AuthorDtos;

namespace Contracts.Services
{
    public interface IAuthorService
    {
        Task CreateAuthorAsync(AuthorForCreateDto authorForCreateDto, CancellationToken cancellationToken = default);
        IEnumerable<AuthorDto> FindAuthorById(int id);
        IEnumerable<AuthorDto> GetAllAuthor();
        Task UpdateAuthorAsync(AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    }
}
