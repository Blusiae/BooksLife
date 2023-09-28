namespace BooksLife.Core
{
    public interface IBookManager
    {
        Response Add(AddBookDto bookDto);
        bool ChangeAvailability(Guid id);
        Response Remove(Guid id);
        IEnumerable<BookDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount);
        IEnumerable<BookDto> GetAllUnborrowed();
        BookDto Get(Guid id);
    }
}
