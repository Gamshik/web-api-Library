using Entites.DataTransferObjects.AuthorDtos;

namespace Interfaces.Services
{
    public interface IAuthorService
    {
        Task CreateAuthorAsync(AuthorForCreateDto authorForCreateDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<AuthorDto>?> GetAllAuthorAsync(CancellationToken cancellationToken = default);
        Task<AuthorDto?> FindAuthorByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAuthorAsync(AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    }
}
