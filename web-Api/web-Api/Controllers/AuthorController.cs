using Contracts.Managers;
using Contracts.Services;
using Entites.DataTransferObjects.AuthorDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Authorize(Roles = "Visitor, Admin")]
    [Route("api/author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ILoggerManager _loggerManager;
        public AuthorController(IAuthorService authorService, ILoggerManager loggerManager)
        {
            _authorService = authorService;
            _loggerManager = loggerManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo("Author creation request!");

            await _authorService.CreateAuthorAsync(authorForCreateDto, cancellationToken);

            _loggerManager.LogInfo("A new author has been created!");

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAuthorsAsync()
        {
            _loggerManager.LogInfo("A request to obtain all authors!");

            var authors = _authorService.GetAllAuthor();

            return Ok(authors);
        }
        [HttpGet("{id}")]
        public IActionResult FindAuthorById(int id)
        {
            _loggerManager.LogInfo("Request to get author by id!");

            var author = _authorService.FindAuthorById(id);

            return Ok(author);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync(AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request for update author(id = {authorForUpdateDto.Id}) info!");

            await _authorService.UpdateAuthorAsync(authorForUpdateDto, cancellationToken);

            _loggerManager.LogInfo($"Info about author with id = {authorForUpdateDto.Id} has been updated!");

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request for delete author with id = {id}!");

            await _authorService.DeleteAuthorAsync(id, cancellationToken);

            _loggerManager.LogInfo($"Author with id = {id} has been deleted!");

            return Ok();
        }
    }
}
