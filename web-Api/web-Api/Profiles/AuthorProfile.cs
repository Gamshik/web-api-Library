using AutoMapper;
using Entites.DataTransferObjects.AuthorDtos;
using Entites.Entities;

namespace web_Api.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<AuthorForCreateDto, Author>();
            CreateMap<AuthorForUpdateDto, Author>();
        }
    }
}
