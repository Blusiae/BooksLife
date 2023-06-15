namespace BooksLife.Core
{
    public static class DtoToEntity
    {
        public static AuthorEntity ToEntity(this AddAuthorDto dto)
            => new()
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };

        public static List<AuthorEntity> ToEntity(this IEnumerable<AddAuthorDto> dtos)
            => dtos.Select(x => x.ToEntity()).ToList();

        public static ReaderEntity ToEntity(this AddReaderDto dto)
            => new()
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Birthdate = dto.Birthdate,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Address = new AddressEntity()
                {
                    Country = dto.Country,
                    City = dto.City,
                    PostalCode = dto.PostalCode,
                    Street = dto.Street,
                    HouseNumber = dto.HouseNumber,
                    FlatNumber = dto.FlatNumber
                }
            };

        public static List<ReaderEntity> ToEntity(this IEnumerable<AddReaderDto> dtos)
            => dtos.Select(x => x.ToEntity()).ToList();

        public static BookEntity ToEntity(this AddBookDto dto)
            => new()
            {
                IsBorrowed = dto.IsBorrowed,
                BookTitleId = dto.BookTitleId,
                EditionPublicationYear = dto.EditionPublicationYear,
                Condition = dto.Condition,
                ConditionNote = dto.ConditionNote
            };

        public static List<BookEntity> ToEntity(this IEnumerable<AddBookDto> dtos)
            => dtos.Select(x => x.ToEntity()).ToList();

        public static BookTitleEntity ToEntity(this AddBookTitleDto dto)
            => new()
            {
                Title = dto.Title,
                PublicationYear = dto.PublicationYear,
                AuthorId = dto.AuthorId
            };

        public static List<BookTitleEntity> ToEntity(this IEnumerable<AddBookTitleDto> dtos)
            => dtos.Select(x => x.ToEntity()).ToList();

    }
}
