using BooksLife.Core;

namespace BooksLife.Web
{
    public interface IViewModelMapper
    {
        AuthorViewModel Map(AuthorDto author);
        AuthorDto Map(AuthorViewModel author);
        IEnumerable<AuthorViewModel> Map(IEnumerable<AuthorDto> authors);
        IEnumerable<AuthorDto> Map(IEnumerable<AuthorViewModel> authors);
    }
}