using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Providers
{
    public interface IJwtProvider
    {
        Task<Jwt?> CreateJwtAsync(User user, CancellationToken cancellationToken = default);
    }
}
