using AutoMapper;
using Entites.DataTransferObjects.IssueDtos;
using Entites.Entities;
using FluentValidation;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Web_Api.BLL.Services
{
    public class IssueService : IIssueService
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        private readonly IValidator<Issue> _issueValidator;
        public IssueService(IMapper mapper, IIssueRepository issueRepository, IValidator<Issue> issueValidator)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;
            _issueValidator = issueValidator;
        }
        public async Task CreateIssueAsync(IssueForCreateDto issueForCreateDto, CancellationToken cancellationToken = default)
        {
            var issue = _mapper.Map<Issue>(issueForCreateDto);

            await _issueValidator.ValidateAndThrowAsync(issue, cancellationToken);

            await _issueRepository.CreateIssueAsync(issue, cancellationToken);
        }

        public async Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default)
        {
            await _issueRepository.DeleteIssueAsync(id, cancellationToken);
        }

        public async Task<IssueDto?> FindIssueByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IssueDto>(await _issueRepository.FindIssueByIdAsync(id, cancellationToken));
        }

        public async Task<IEnumerable<IssueDto>?> GetAllIssuesAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<IssueDto>>(await _issueRepository.GetAllIssuesAsync(cancellationToken));
        }

        public async Task UpdateIssueAsync(IssueForUpdateDto issueForUpdateDto, CancellationToken cancellationToken = default)
        {
            var issue = _mapper.Map<Issue>(issueForUpdateDto);

            await _issueValidator.ValidateAndThrowAsync(issue, cancellationToken);

            await _issueRepository.UpdateIssueAsync(issue, cancellationToken);
        }
    }
}
