using BooksLife.Core;

namespace BooksLife.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public IReaderRepository ReaderRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IBorrowRepository BorrowRepository { get; }

        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(IBookRepository bookRepository, IReaderRepository readerRepository, IAuthorRepository authorRepository,
            IBorrowRepository borrowRepository, ApplicationDbContext dbContext)
        {
            BookRepository = bookRepository;
            ReaderRepository = readerRepository;
            AuthorRepository = authorRepository;
            BorrowRepository = borrowRepository;
            _dbContext = dbContext;
        }

        public bool Commit()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
