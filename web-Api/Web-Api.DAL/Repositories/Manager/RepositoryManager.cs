using Contracts.Managers;
using Contracts.Repositories;
using Web_Api.DAL.Context;

namespace Web_Api.DAL.Repositories.Manager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly LibraryContext _libraryContext;
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;
        private IIssueRepository _issueRepository;
        private IReaderRepository _readerRepository;

        public RepositoryManager(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public IAuthorRepository Author
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_libraryContext);
                }


                return _authorRepository;
            }
        }
        public IBookRepository Book
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_libraryContext);
                }

                return _bookRepository;
            }
        }
        public IIssueRepository Issue
        {
            get
            {
                if (_issueRepository == null)
                {
                    _issueRepository = new IssueRepository(_libraryContext);
                }

                return _issueRepository;
            }
        }
        public IReaderRepository Reader
        {
            get
            {
                if (_readerRepository == null)
                {
                    _readerRepository = new ReaderRepository(_libraryContext);
                }

                return _readerRepository;
            }
        }
        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _libraryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
