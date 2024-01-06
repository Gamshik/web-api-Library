using Contracts.Managers;
using Contracts.Services;
using Entites.DataTransferObjects.BookDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Authorize(Roles = "Visitor, Admin")]
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILoggerManager _loggerManager;
        public BookController(IBookService bookService, ILoggerManager loggerManager)
        {
            _bookService = bookService;
            _loggerManager = loggerManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync(BookForCreateDto bookForCreateDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo("Book creation request!");

            await _bookService.CreateBookAsync(bookForCreateDto, cancellationToken);

            _loggerManager.LogInfo("A new book has been created!");

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            _loggerManager.LogInfo("A request to obtain all books!");

            var books = _bookService.GetAllBooks();

            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult FindBookById(int id)
        {
            _loggerManager.LogInfo("Request to get book by id!");

            var book = _bookService.FindBookById(id);

            return Ok(book);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync(BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request for update book(id = {bookForUpdateDto.Id}) info!");

            await _bookService.UpdateBookAsync(bookForUpdateDto, cancellationToken);

            _loggerManager.LogInfo($"Info about book with id = {bookForUpdateDto.Id} has been updated!");

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request for delete book with id = {id}!");

            await _bookService.DeleteBookAsync(id, cancellationToken);

            _loggerManager.LogInfo($"Book with id = {id} has been deleted!");

            return Ok();
        }
    }
}
