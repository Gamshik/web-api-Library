using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(User user, string password, CancellationToken cancellationToken = default);
        Task<User?> AuthenticateAsync(User user, string password, CancellationToken cancellationToken = default);
    }
}
