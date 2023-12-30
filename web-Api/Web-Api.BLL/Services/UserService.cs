using AutoMapper;
using Entities.DataTransferObjects.UserDtos;
using Entities.Entities;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            return await _userRepository.RegisterUserAsync(user, userForRegistrationDto.Password, cancellationToken);
        }
        public Task<Jwt?> AuthorizeAsync(UserForAuthorizeDto userForAuthorizeDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
