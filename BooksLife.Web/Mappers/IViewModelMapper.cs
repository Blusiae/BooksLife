using BooksLife.Core;

namespace BooksLife.Web
{
    public interface IViewModelMapper
    {
        AuthorViewModel Map(AuthorDto author);
        AuthorDto Map(AuthorViewModel author);
        IEnumerable<AuthorViewModel> Map(IEnumerable<AuthorDto> authors);
        IEnumerable<AuthorDto> Map(IEnumerable<AuthorViewModel> authors);
        ReaderViewModel Map(ReaderDto reader);
        ReaderDto Map(ReaderViewModel reader);
        IEnumerable<ReaderViewModel> Map(IEnumerable<ReaderDto> readers);
        IEnumerable<ReaderDto> Map(IEnumerable<ReaderViewModel> readers);
        BookViewModel Map(BookDto book);
        BookDto Map(BookViewModel book);
        IEnumerable<BookViewModel> Map(IEnumerable<BookDto> books);
        IEnumerable<BookDto> Map(IEnumerable<BookViewModel> books);
        BookTitleViewModel Map(BookTitleDto bookTitle);
        BookTitleDto Map(BookTitleViewModel bookTitle);
        IEnumerable<BookTitleViewModel> Map(IEnumerable<BookTitleDto> bookTitles);
        IEnumerable<BookTitleDto> Map(IEnumerable<BookTitleViewModel> bookTitles);
    }
}