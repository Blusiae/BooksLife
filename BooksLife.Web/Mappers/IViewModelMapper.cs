using BooksLife.Core;

namespace BooksLife.Web
{
    public interface IViewModelMapper
    {
        AuthorViewModel Map(AuthorDto reader);
        AuthorDto Map(AuthorViewModel reader);
        IEnumerable<AuthorViewModel> Map(IEnumerable<AuthorDto> readers);
        IEnumerable<AuthorDto> Map(IEnumerable<AuthorViewModel> readers);
        ReaderViewModel Map(ReaderDto reader);
        ReaderDto Map(ReaderViewModel reader);
        IEnumerable<ReaderViewModel> Map(IEnumerable<ReaderDto> readers);
        IEnumerable<ReaderDto> Map(IEnumerable<ReaderViewModel> readers);
    }
}