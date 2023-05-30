namespace BooksLife.Core
{
    public interface IAuthorManager
    {
        Response Add(AuthorDto author);
        Response Remove(Guid id);
        AuthorDto Get(Guid id);
        List<AuthorDto> GetAll();
    }
}
