using Entites.DataTransferObjects.IssueDtos;
using Interfaces.Managers;
using Interfaces.Services;
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
        public async Task<IActionResult> GetAllIssuesAsync(CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo("A request to obtain all issues!");

            var issues = await _issueService.GetAllIssuesAsync(cancellationToken);

            return Ok(issues);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindIssueByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo("Request to get issue by id!");

            var issue = await _issueService.FindIssueByIdAsync(id, cancellationToken);

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
