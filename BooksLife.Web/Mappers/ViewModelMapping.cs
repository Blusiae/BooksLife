using BooksLife.Web;

namespace BooksLife.Core
{
    public static class ViewModelMapping
    {
        public static AuthorViewModel ToViewModel(this AuthorDto dto)
            => new()
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };

        public static AddAuthorDto ToDto(this AddAuthorViewModel viewModel)
            => new()
            {
                Firstname = viewModel.Firstname,
                Lastname = viewModel.Lastname
            };

        public static List<AuthorViewModel> ToViewModel(this IEnumerable<AuthorDto> dtos)
            => dtos.Select(x => x.ToViewModel()).ToList();

        public static BookTitleViewModel ToViewModel(this BookTitleDto dto)
            => new()
            {
                Id = dto.Id,
                Title = dto.Title,
                PublicationYear = dto.PublicationYear,
                AuthorName = dto.AuthorName,
            };

        public static AddBookTitleDto ToDto(this AddBookTitleViewModel viewModel)
            => new()
            {
                Title = viewModel.Title,
                PublicationYear = viewModel.PublicationYear,
                AuthorId = viewModel.AuthorId
            };

        public static List<BookTitleViewModel> ToViewModel(this IEnumerable<BookTitleDto> dtos)
            => dtos.Select(x => x.ToViewModel()).ToList();
    }
}
