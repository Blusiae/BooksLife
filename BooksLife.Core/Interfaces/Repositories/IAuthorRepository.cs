namespace BooksLife.Core
{
    public interface IAuthorRepository : IBaseRepository<AuthorEntity>
    {
        IEnumerable<AuthorEntity> GetAll(out int totalCount, int take, int skip = 0, string? filterString = null);
    }
}
