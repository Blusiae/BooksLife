namespace BooksLife.Core
{
    public static class EntityToDto
    {
        public static AuthorDto ToDto(this AuthorEntity entity)
            => new()
            {
                Id = entity.Id,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname
            };

        public static List<AuthorDto> ToDto(this IEnumerable<AuthorEntity> entities)
            => entities.Select(x => x.ToDto()).ToList();

        public static ReaderDto ToDto(this ReaderEntity entity)
            => new()
            {
                Id = entity.Id,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
                Birthdate = entity.Birthdate,
                EmailAddress = entity.EmailAddress,
                PhoneNumber = entity.PhoneNumber,
                Country = entity.Address.Country,
                City = entity.Address.City,
                Street = entity.Address.Street,
                PostalCode = entity.Address.PostalCode,
                HouseNumber = entity.Address.HouseNumber,
                FlatNumber = entity.Address.FlatNumber
            };

        public static List<ReaderDto> ToDto(this IEnumerable<ReaderEntity> entities)
            => entities.Select(x => x.ToDto()).ToList();

        public static BookDto ToDto(this BookEntity entity) 
            => new()
            {
                Id = entity.Id,
                Title = entity.BookTitle.Title,
                IsBorrowed = entity.IsBorrowed,
                AuthorName = $"{entity.BookTitle.Author.Firstname} {entity.BookTitle.Author.Lastname}",
                PublicationYear = entity.BookTitle.PublicationYear,
                EditionPublicationYear = entity.EditionPublicationYear,
                Condition = entity.Condition,
                ConditionNote = entity.ConditionNote
            };

        public static List<BookDto> ToDto(this IEnumerable<BookEntity> entities)
            => entities.Select(x => x.ToDto()).ToList();


        public static BorrowDto ToDto(this BorrowEntity entity)
            => new()
            {
                Id = entity.Id,
                IsActive = entity.IsActive,
                Book = entity.Book.ToDto(),
                Reader = entity.Reader.ToDto(),
                BorrowDate = entity.BorrowDate,
                ReturnDate = entity.ReturnDate
            };

        public static List<BorrowDto> ToDto(this IEnumerable<BorrowEntity> entities)
            => entities.Select(x => x.ToDto()).ToList();
    }
}
