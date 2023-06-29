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

        public static BookViewModel ToViewModel(this BookDto dto)
            => new()
            {
                Id = dto.Id,
                IsBorrowed = dto.IsBorrowed,
                Title = dto.Title,
                PublicationYear = dto.PublicationYear,
                AuthorName = dto.AuthorName,
                EditionPublicationYear = dto.EditionPublicationYear,
                Condition = dto.Condition,
                ConditionNote = dto.ConditionNote,
            };

        public static AddBookDto ToDto(this AddBookViewModel viewModel)
            => new()
            {
                IsBorrowed = false,
                BookTitleId = viewModel.BookTitleId,
                EditionPublicationYear = viewModel.EditionPublicationYear,
                Condition = viewModel.Condition,
                ConditionNote = viewModel.ConditionNote,
            };

        public static List<BookViewModel> ToViewModel(this IEnumerable<BookDto> dtos)
            => dtos.Select(x => x.ToViewModel()).ToList();
    }
}
