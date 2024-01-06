using AutoMapper;
using Contracts.Managers;
using Contracts.Services;
using Entites.DataTransferObjects.IssueDtos;
using Entites.Entities;
using FluentValidation;

namespace Web_Api.BLL.Services
{
    public class IssueService : IIssueService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IValidator<Issue> _issueValidator;

        public IssueService(IMapper mapper, IRepositoryManager repositoryManager, IValidator<Issue> issueValidator)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _issueValidator = issueValidator;
        }

        public async Task CreateIssueAsync(IssueForCreateDto issueForCreateDto, CancellationToken cancellationToken = default)
        {
            var issue = _mapper.Map<Issue>(issueForCreateDto);

            await _issueValidator.ValidateAndThrowAsync(issue, cancellationToken);

            await _repositoryManager.Issue.CreateIssueAsync(issue, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
        public IEnumerable<IssueDto> FindIssueById(int id)
        {
            return _mapper.Map<IEnumerable<IssueDto>>(_repositoryManager.Issue.FindIssueById(id));
        }
        public IEnumerable<IssueDto> GetAllIssues()
        {
            return _mapper.Map<IEnumerable<IssueDto>>(_repositoryManager.Issue.GetAllIssues());
        }
        public async Task UpdateIssueAsync(IssueForUpdateDto issueForUpdateDto, CancellationToken cancellationToken = default)
        {
            var issue = _mapper.Map<Issue>(issueForUpdateDto);

            await _issueValidator.ValidateAndThrowAsync(issue, cancellationToken);

            await _repositoryManager.Issue.UpdateIssueAsync(issue, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
        public async Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default)
        {
            await _repositoryManager.Issue.DeleteIssueAsync(id, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
    }
}
