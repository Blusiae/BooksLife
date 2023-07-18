namespace BooksLife.Core
{
    public interface IReaderRepository : IBaseRepository<ReaderEntity>
    {
        IEnumerable<ReaderEntity> GetAll(out int totalCount, int take, int skip = 0, string? filterString = null);
    }
}
