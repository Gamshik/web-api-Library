using Entities.Entities;
using Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> RegisterUserAsync(User user, string password, CancellationToken cancellationToken = default)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public Task<Jwt?> AuthorizeAsync(User user, string password, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
