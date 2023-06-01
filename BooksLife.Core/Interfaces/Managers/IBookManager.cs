namespace BooksLife.Core
{
    public interface IBookManager
    {
        Response Add(BookDto bookDto);
        Response Remove(Guid id);
        List<BookDto> GetAll();
        BookDto Get(Guid id);
    }
}
