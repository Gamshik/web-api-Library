using AutoMapper;
using Entities.DataTransferObjects.UserDtos;
using Entities.Entities;

namespace web_Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForAuthorizeDto, User>();
        }
    }
}
