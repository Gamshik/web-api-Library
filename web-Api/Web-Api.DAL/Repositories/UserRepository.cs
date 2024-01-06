using Contracts.Repositories;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

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
            var result = await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, "Visitor");
            //await _userManager.AddToRoleAsync(user, "Admin");
            return result;
        }
        public async Task<User?> AuthenticateAsync(User user, string password, CancellationToken cancellationToken = default)
        {
            var foundUser = await _userManager.FindByEmailAsync(user.Email);

            if (foundUser != null)
            {
                if (await _userManager.CheckPasswordAsync(foundUser, password))
                {
                    return foundUser;
                }

                return null;
            }

            return null;
        }
    }
}
