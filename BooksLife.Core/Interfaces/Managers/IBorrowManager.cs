namespace BooksLife.Core
{
    public interface IBorrowManager
    {
        Response Add(AddBorrowDto borrowDto);
        Response Remove(Guid id);
        Response SetAsReturned(ReturnDto returnDto);
        IEnumerable<BorrowDto> GetPage(int pageSize, int pageNumber, out int totalCount);
        BorrowDto Get(Guid id);
    }
}
