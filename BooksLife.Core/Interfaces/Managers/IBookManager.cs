namespace BooksLife.Core
{
    public interface IBookManager
    {
        Response Add(AddBookDto bookDto);
        Response Remove(Guid id);
        List<BookDto> GetAll();
        BookDto Get(Guid id);
    }
}
