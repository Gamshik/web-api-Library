using Contracts.Managers;
using Contracts.Services;
using Entites.DataTransferObjects.IssueDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/issue")]
    [ApiController]
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        private readonly ILoggerManager _loggerManager;
        public IssueController(IIssueService issueService, ILoggerManager loggerManager)
        {
            _issueService = issueService;
            _loggerManager = loggerManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateIssueAsync(IssueForCreateDto issueForCreateDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo("Issue creation request!");

            await _issueService.CreateIssueAsync(issueForCreateDto, cancellationToken);

            _loggerManager.LogInfo("A new issue has been created!");

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllIssues()
        {
            _loggerManager.LogInfo("A request to obtain all issues!");

            var issues = _issueService.GetAllIssues();

            return Ok(issues);
        }
        [HttpGet("{id}")]
        public IActionResult FindIssueById(int id)
        {
            _loggerManager.LogInfo("Request to get issue by id!");

            var issue = _issueService.FindIssueById(id);

            return Ok(issue);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateIssueAsync(IssueForUpdateDto issueForUpdateDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request for update issue(id = {issueForUpdateDto.Id}) info!");

            await _issueService.UpdateIssueAsync(issueForUpdateDto, cancellationToken);

            _loggerManager.LogInfo($"Info about issue with id = {issueForUpdateDto.Id} has been updated!");

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssueAsync(int id, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request for delete issue with id = {id}!");

            await _issueService.DeleteIssueAsync(id, cancellationToken);

            _loggerManager.LogInfo($"Issue with id = {id} has been deleted!");

            return Ok();
        }
    }
}
