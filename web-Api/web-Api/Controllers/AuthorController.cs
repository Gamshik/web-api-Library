using Entites.DataTransferObjects.AuthorDtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Authorize(Roles = "Visitor")]
    [Route("api/author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto, CancellationToken cancellationToken = default)
        {
            await _authorService.CreateAuthorAsync(authorForCreateDto, cancellationToken);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthorsAsync(CancellationToken cancellationToken = default)
        {
            var authors = await _authorService.GetAllAuthorAsync();

            return Ok(authors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindAuthorByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var author = await _authorService.FindAuthorByIdAsync(id);

            return Ok(author);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync(AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken = default)
        {
            await _authorService.UpdateAuthorAsync(authorForUpdateDto, cancellationToken);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
        {
            await _authorService.DeleteAuthorAsync(id, cancellationToken);

            return Ok();
        }
    }
}
