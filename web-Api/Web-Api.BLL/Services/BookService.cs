using AutoMapper;
using Contracts.Managers;
using Contracts.Services;
using Entites.DataTransferObjects.BookDtos;
using Entites.Entities;
using FluentValidation;

namespace Web_Api.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IValidator<Book> _bookValidator;

        public BookService(IMapper mapper, IRepositoryManager repositoryManager, IValidator<Book> bookValidator)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _bookValidator = bookValidator;
        }

        public async Task CreateBookAsync(BookForCreateDto bookForCreateDto, CancellationToken cancellationToken = default)
        {
            var book = _mapper.Map<Book>(bookForCreateDto);

            await _bookValidator.ValidateAndThrowAsync(book, cancellationToken);

            await _repositoryManager.Book.CreateBookAsync(book, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
        public IEnumerable<BookDto> FindBookById(int id)
        {
            return _mapper.Map<IEnumerable<BookDto>>(_repositoryManager.Book.FindBookById(id));
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            return _mapper.Map<IEnumerable<BookDto>>(_repositoryManager.Book.GetAllBooks());
        }
        public async Task UpdateBookAsync(BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default)
        {
            var book = _mapper.Map<Book>(bookForUpdateDto);

            await _bookValidator.ValidateAndThrowAsync(book, cancellationToken);

            await _repositoryManager.Book.UpdateBookAsync(book, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
        public async Task DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            await _repositoryManager.Book.DeleteBookAsync(id, cancellationToken);

            await _repositoryManager.SaveAsync(cancellationToken);
        }
    }
}