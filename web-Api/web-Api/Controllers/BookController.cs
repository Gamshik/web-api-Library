using Entites.DataTransferObjects.BookDtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Authorize(Roles = "Visitor, Admin")]
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync(BookForCreateDto bookForCreateDto, CancellationToken cancellationToken = default)
        {
            await _bookService.CreateBookAsync(bookForCreateDto, cancellationToken);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync(CancellationToken cancellationToken = default)
        {
            var books = await _bookService.GetAllBooksAsync(cancellationToken);

            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var book = await _bookService.FindBookByIdAsync(id, cancellationToken);

            return Ok(book);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync(BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default)
        {
            await _bookService.UpdateBookAsync(bookForUpdateDto, cancellationToken);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            await _bookService.DeleteBookAsync(id, cancellationToken);

            return Ok();
        }
    }
}
