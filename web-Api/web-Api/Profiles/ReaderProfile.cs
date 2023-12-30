using AutoMapper;
using Entites.DataTransferObjects.ReaderDtos;
using Entites.Entities;

namespace web_Api.Profiles
{
    public class ReaderProfile : Profile
    {
        public ReaderProfile()
        {
            CreateMap<ReaderDto, Reader>().ReverseMap();
            CreateMap<ReaderForCreateDto, Reader>();
            CreateMap<ReaderForUpdateDto, Reader>();
        }
    }
}
