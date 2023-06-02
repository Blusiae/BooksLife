namespace BooksLife.Core
{
    public interface IBookRepository : IBaseRepository<BookEntity>
    {
        bool SetAsBorrowed(Guid id);
        bool SetAsUnborrowed(Guid id);
    }
}
