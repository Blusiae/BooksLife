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

        public static ReaderViewModel ToViewModel(this ReaderDto dto)
            => new()
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Birthdate = dto.Birthdate,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Country = dto.Country,
                City = dto.City,
                PostalCode = dto.PostalCode,
                Street = dto.Street,
                HouseNumber = dto.HouseNumber,
                FlatNumber = dto.FlatNumber,
            };

        public static AddReaderDto ToDto(this AddReaderViewModel viewModel)
            => new()
            {
                Firstname = viewModel.Firstname,
                Lastname = viewModel.Lastname,
                Birthdate = viewModel.Birthdate,
                EmailAddress = viewModel.EmailAddress,
                PhoneNumber = viewModel.PhoneNumber,
                Country = viewModel.Country,
                City = viewModel.City,
                PostalCode = viewModel.PostalCode,
                Street = viewModel.Street,
                HouseNumber = viewModel.HouseNumber,
                FlatNumber = viewModel.FlatNumber,
            };

        public static List<ReaderViewModel> ToViewModel(this IEnumerable<ReaderDto> dtos) 
            => dtos.Select(x => x.ToViewModel()).ToList();

        public static BorrowViewModel ToViewModel(this BorrowDto dto)
            => new()
            {
                Id = dto.Id,
                IsActive = dto.IsActive,
                Reader = dto.Reader.ToViewModel(),
                Book = dto.Book.ToViewModel(),
                BorrowDate = dto.BorrowDate,
                ReturnDate = dto.ReturnDate
            };

        public static AddBorrowDto ToDto(this AddBorrowViewModel viewModel)
            => new()
            {
                BookId = viewModel.BookId,
                ReaderId = viewModel.ReaderId,
                ReturnDate = viewModel.ReturnDate,
                IsActive = true
            };

        public static List<BorrowViewModel> ToViewModel(this IEnumerable<BorrowDto> dtos)
            => dtos.Select(x => x.ToViewModel()).ToList();
    }
}
