namespace BooksLife.Core
{
    public interface IBorrowRepository : IBaseRepository<BorrowEntity>
    {
        bool SetAsUnactive(Guid id);
        bool SetAsActive (Guid id);
    }
}
