using Entities.DataTransferObjects.UserDtos;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto, CancellationToken cancellationToken = default);
        Task<Jwt?> AuthorizeAsync(UserForAuthorizeDto userForAuthorizeDto, CancellationToken cancellationToken = default);
    }
}
