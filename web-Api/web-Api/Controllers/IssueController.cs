using AutoMapper;
using Entites.DataTransferObjects.IssueDtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Route("api/issue")]
    [ApiController]
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        public IssueController(IMapper mapper, IIssueService issueService)
        {
            _issueService = issueService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateIssueAsync(IssueForCreateDto issueForCreateDto, CancellationToken cancellationToken = default)
        {
            await _issueService.CreateIssueAsync(issueForCreateDto, cancellationToken);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIssuesAsync(CancellationToken cancellationToken = default)
        {
            var issues = await _issueService.GetAllIssuesAsync(cancellationToken);

            return Ok(issues);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindIssueByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var issue = await _issueService.FindIssueByIdAsync(id, cancellationToken);

            return Ok(issue);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateIssueAsync(IssueForUpdateDto issueForUpdateDto, CancellationToken cancellationToken = default)
        {
            await _issueService.UpdateIssueAsync(issueForUpdateDto, cancellationToken);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssueAsync(int id, CancellationToken cancellationToken = default)
        {
            await _issueService.DeleteIssueAsync(id, cancellationToken);

            return Ok();
        }
    }
}
