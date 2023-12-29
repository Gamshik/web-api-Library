using AutoMapper;
using Entites.DataTransferObjects.IssueDtos;
using Entites.Entities;

namespace Web_Api.BLL.Profiles
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
