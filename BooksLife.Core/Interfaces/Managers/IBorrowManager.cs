namespace BooksLife.Core
{
    public interface IBorrowManager
    {
        Response Add(BorrowDto borrowDto);
        Response Remove(Guid id);
        List<BorrowDto> GetAll();
        BorrowDto Get(Guid id);
    }
}
