namespace BooksLife.Core
{
    public interface IBookTitleManager
    {
        Response Add(BookTitleDto bookTitleDto);
        Response Remove(Guid id);
        List<BookTitleDto> GetAll();
    }
}
