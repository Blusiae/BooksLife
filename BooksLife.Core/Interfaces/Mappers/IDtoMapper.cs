namespace BooksLife.Core
{
    public interface IDtoMapper
    {
        AuthorEntity Map(AuthorDto Author);
        AuthorDto Map(AuthorEntity Author);
        IEnumerable<AuthorEntity> Map(IEnumerable<AuthorDto> Authors);
        IEnumerable<AuthorDto> Map(IEnumerable<AuthorEntity> Authors);
    }
}