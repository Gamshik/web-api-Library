using AutoMapper;
using Entites.DataTransferObjects.BookDtos;
using Entites.Entities;

namespace web_Api.Profiles
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
