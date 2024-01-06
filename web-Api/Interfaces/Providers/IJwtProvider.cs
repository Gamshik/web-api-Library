using Entities.Entities;

namespace Interfaces.Providers
{
    public interface IJwtProvider
    {
        Task<Jwt?> CreateJwtAsync(User user, CancellationToken cancellationToken = default);
    }
}
