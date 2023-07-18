namespace BooksLife.Core
{
    public interface IBookRepository : IBaseRepository<BookEntity>
    {
        IEnumerable<BookEntity> GetAll(out int totalCount, int take, int skip = 0, string? filterString = null);
    }
}
