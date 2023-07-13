namespace BooksLife.Core
{
    public interface IBorrowRepository : IBaseRepository<BorrowEntity>
    {
        IEnumerable<BorrowEntity> GetAll();
    }
}
