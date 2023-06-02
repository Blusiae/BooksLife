namespace BooksLife.Core
{
    public interface IBorrowManager
    {
        Response Add(BorrowDto borrowDto);
        Response Remove(Guid id);
        Response SetAsReturned(BorrowDto borrowDto);
        List<BorrowDto> GetAll();
        BorrowDto Get(Guid id);
    }
}
