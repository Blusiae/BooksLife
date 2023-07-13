namespace BooksLife.Core
{
    public interface IBorrowManager
    {
        Response Add(AddBorrowDto borrowDto);
        Response Remove(Guid id);
        Response SetAsReturned(ReturnDto returnDto);
        IEnumerable<BorrowDto> GetAll();
        BorrowDto Get(Guid id);
    }
}
