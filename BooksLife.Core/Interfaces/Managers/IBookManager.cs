namespace BooksLife.Core
{
    public interface IBookManager
    {
        Response Add(AddBookDto bookDto);
        bool ChangeAvailability(Guid id);
        Response Remove(Guid id);
        List<BookDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount);
        List<BookDto> GetAllUnborrowed();
        BookDto Get(Guid id);
    }
}
