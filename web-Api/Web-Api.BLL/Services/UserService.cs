using AutoMapper;
using Contracts.Providers;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.UserDtos;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace Web_Api.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        public UserService(IMapper mapper, IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }
        public async Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            return await _userRepository.RegisterUserAsync(user, userForRegistrationDto.Password, cancellationToken);
        }
        public async Task<Jwt?> AuthorizeAsync(UserForAuthorizeDto userForAuthorizeDto, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(userForAuthorizeDto);
            var authenticateUser = await _userRepository.AuthenticateAsync(user, userForAuthorizeDto.Password, cancellationToken);
            if (authenticateUser != null)
            {
                return await _jwtProvider.CreateJwtAsync(authenticateUser, cancellationToken);
            }
            return null;
        }
    }
}
