using Entities.Entities;

namespace Contracts.Providers
{
    public interface IJwtProvider
    {
        Task<Jwt?> CreateJwtAsync(User user, CancellationToken cancellationToken = default);
    }
}
