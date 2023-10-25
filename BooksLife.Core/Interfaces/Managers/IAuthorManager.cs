namespace BooksLife.Core
{
    public interface IAuthorManager
    {
        Response Add(AddAuthorDto author);
        Response Remove(Guid id);
        AuthorDto Get(Guid id);
        List<AuthorDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount);
        List<AuthorDto> GetAll();
    }
}
