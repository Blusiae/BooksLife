namespace BooksLife.Core
{
    public interface IAuthorManager
    {
        Response Add(AddAuthorDto author);
        Response Remove(Guid id);
        AuthorDto Get(Guid id);
        IEnumerable<AuthorDto> GetAll(int pageSize, int pageNumber, out int totalCount);
        IEnumerable<AuthorDto> GetAll();
    }
}
