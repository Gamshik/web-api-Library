using Entities.DataTransferObjects.UserDtos;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto, CancellationToken cancellationToken = default);
        Task<Jwt?> AuthorizeAsync(UserForAuthorizeDto userForAuthorizeDto, CancellationToken cancellationToken = default);
    }
}
