namespace BooksLife.Core
{
    public interface IDtoMapper
    {
        AuthorEntity Map(AuthorDto Author);
        AuthorDto Map(AuthorEntity Author);
        IEnumerable<AuthorEntity> Map(IEnumerable<AuthorDto> Authors);
        IEnumerable<AuthorDto> Map(IEnumerable<AuthorEntity> Authors);
        ReaderEntity Map(ReaderDto Reader);
        ReaderDto Map(ReaderEntity Reader);
        IEnumerable<ReaderEntity> Map(IEnumerable<ReaderDto> Readers);
        IEnumerable<ReaderDto> Map(IEnumerable<ReaderEntity> Readers);
    }
}