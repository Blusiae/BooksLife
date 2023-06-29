namespace BooksLife.Core
{
    public interface IBookTitleManager
    {
        Response Add(AddBookTitleDto bookTitleDto);
        Response Remove(Guid id);
        List<BookTitleDto> GetAll();
    }
}
