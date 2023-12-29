using Entites.DataTransferObjects.ReaderDtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Route("api/reader")]
    [ApiController]
    public class ReaderController : Controller
    {
        private readonly IReaderService _readerService;
        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReaderAsync(ReaderForCreateDto readerForCreateDto, CancellationToken cancellationToken = default)
        {
            await _readerService.CreateReaderAsync(readerForCreateDto, cancellationToken);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReadersAsync(CancellationToken cancellationToken = default)
        {
            var readers = await _readerService.GetAllReadersAsync(cancellationToken);

            return Ok(readers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindReaderByIdAsync(int id, CancellationToken cancellationToken)
        {
            var reader = await _readerService.FindReaderByIdAsync(id, cancellationToken);

            return Ok(reader);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReaderAsync(ReaderForUpdateDto readerForUpdateDto, CancellationToken cancellationToken = default)
        {
            await _readerService.UpdateReaderAsync(readerForUpdateDto, cancellationToken);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaderAsync(int id, CancellationToken cancellationToken = default)
        {
            await _readerService.DeleteReaderAsync(id, cancellationToken);

            return Ok();
        }
    }
}
