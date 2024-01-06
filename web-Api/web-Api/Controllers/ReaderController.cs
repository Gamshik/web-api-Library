using Contracts.Managers;
using Contracts.Services;
using Entites.DataTransferObjects.ReaderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/reader")]
    [ApiController]
    public class ReaderController : Controller
    {
        private readonly IReaderService _readerService;
        private readonly ILoggerManager _loggerManager;
        public ReaderController(IReaderService readerService, ILoggerManager loggerManager)
        {
            _readerService = readerService;
            _loggerManager = loggerManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReaderAsync(ReaderForCreateDto readerForCreateDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo("Reader creation request!");

            await _readerService.CreateReaderAsync(readerForCreateDto, cancellationToken);

            _loggerManager.LogInfo("A new reader has been created!");

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllReaders()
        {
            _loggerManager.LogInfo("A request to obtain all readers!");

            var readers = _readerService.GetAllReaders();

            return Ok(readers);
        }
        [HttpGet("{id}")]
        public IActionResult FindReaderById(int id)
        {
            _loggerManager.LogInfo("Request to get reader by id!");

            var reader = _readerService.FindReaderById(id);

            return Ok(reader);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReaderAsync(ReaderForUpdateDto readerForUpdateDto, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request for update reader(id = {readerForUpdateDto.Id}) info!");

            await _readerService.UpdateReaderAsync(readerForUpdateDto, cancellationToken);

            _loggerManager.LogInfo($"Info about reader with id = {readerForUpdateDto.Id} has been updated!");

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaderAsync(int id, CancellationToken cancellationToken = default)
        {
            _loggerManager.LogInfo($"Request for delete reader with id = {id}!");

            await _readerService.DeleteReaderAsync(id, cancellationToken);

            _loggerManager.LogInfo($"Reader with id = {id} has been deleted!");


            return Ok();
        }
    }
}
