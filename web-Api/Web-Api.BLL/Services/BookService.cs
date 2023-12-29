using AutoMapper;
using Entites.DataTransferObjects.BookDtos;
using Entites.Entities;
using FluentValidation;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Web_Api.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IValidator<Book> _bookValidator;
        public BookService(IMapper mapper, IBookRepository bookRepository, IValidator<Book> bookValidator)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookValidator = bookValidator;
        }
        public async Task CreateBookAsync(BookForCreateDto bookForCreateDto, CancellationToken cancellationToken = default)
        {
            var book = _mapper.Map<Book>(bookForCreateDto);

            await _bookValidator.ValidateAndThrowAsync(book, cancellationToken);

            await _bookRepository.CreateBookAsync(book, cancellationToken);
        }

        public async Task DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            await _bookRepository.DeleteBookAsync(id, cancellationToken);
        }

        public async Task<BookDto?> FindBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<BookDto>(await _bookRepository.FindBookByIdAsync(id, cancellationToken));
        }

        public async Task<IEnumerable<BookDto>?> GetAllBooksAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<BookDto>>(await _bookRepository.GetAllBooksAsync(cancellationToken));
        }

        public async Task UpdateBookAsync(BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default)
        {
            var book = _mapper.Map<Book>(bookForUpdateDto);

            await _bookValidator.ValidateAndThrowAsync(book, cancellationToken);

            await _bookRepository.UpdateBookAsync(book, cancellationToken);
        }
    }
}
