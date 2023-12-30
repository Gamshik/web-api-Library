using AutoMapper;
using Entites.DataTransferObjects.IssueDtos;
using Entites.Entities;

namespace web_Api.Profiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<IssueDto, Issue>().ReverseMap();
            CreateMap<IssueForCreateDto, Issue>();
            CreateMap<IssueForUpdateDto, Issue>();
        }
    }
}
