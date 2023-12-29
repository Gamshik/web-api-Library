using AutoMapper;
using Entites.DataTransferObjects.BookDtos;
using Entites.Entities;

namespace Web_Api.BLL.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<BookForCreateDto, Book>();
            CreateMap<BookForUpdateDto, Book>();
        }
    }
}
