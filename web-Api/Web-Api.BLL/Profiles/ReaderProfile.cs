using AutoMapper;
using Entites.DataTransferObjects.ReaderDtos;
using Entites.Entities;

namespace Web_Api.BLL.Profiles
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
