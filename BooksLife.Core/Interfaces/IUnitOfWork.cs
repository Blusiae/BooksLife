namespace BooksLife.Core
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IReaderRepository ReaderRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IBorrowRepository BorrowRepository { get; }

        bool Commit();
    }
}
