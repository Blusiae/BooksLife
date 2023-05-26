namespace BooksLife.Core
{
    public interface IAuthorManager
    {
        Response Add(AuthorDto author);
        Response Delete(int id);
        AuthorDto Get(int id);
        List<AuthorDto> GetAll();
    }
}
