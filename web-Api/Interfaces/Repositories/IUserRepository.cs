using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(User user, string password, CancellationToken cancellationToken = default);
        Task<User?> AuthenticateAsync(User user, string password, CancellationToken cancellationToken = default);
    }
}
