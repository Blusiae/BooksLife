namespace BooksLife.Core
{
    public interface IAuthorManager
    {
        Response Add(AuthorDto author);
        Response Remove(int id);
        AuthorDto Get(int id);
        List<AuthorDto> GetAll();
    }
}
