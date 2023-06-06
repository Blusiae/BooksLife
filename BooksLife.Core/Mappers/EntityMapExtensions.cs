namespace BooksLife.Core
{
    public static class EntityMapExtensions
    {
        public static AuthorEntity ToEntity(this AuthorDto authorDto)
        {
            return new AuthorEntity()
            {
                Id = authorDto.Id,
                Firstname = authorDto.Firstname,
                Lastname = authorDto.Lastname
            };
        }

        public static List<AuthorEntity> ToEntity(this IEnumerable<AuthorDto> authorDtos)
        {
            return authorDtos.Select(x => x.ToEntity()).ToList();
        }

        public static ReaderEntity ToEntity(this ReaderDto readerDto)
        {
            return new ReaderEntity()
            {
                Id = readerDto.Id,
                Firstname = readerDto.Firstname,
                Lastname = readerDto.Lastname,
                Birthdate = readerDto.Birthdate,
                EmailAddress = readerDto.EmailAddress,
                PhoneNumber = readerDto.PhoneNumber,
                Address = new AddressEntity()
                {
                    Country = readerDto.Country,
                    City = readerDto.City,
                    PostalCode = readerDto.PostalCode,
                    Street = readerDto.Street,
                    HouseNumber = readerDto.HouseNumber,
                    FlatNumber = readerDto.FlatNumber
                }
            };
        }

        public static List<ReaderEntity> ToEntity(this IEnumerable<ReaderDto> readerDtos)
        {
            return readerDtos.Select(x => x.ToEntity()).ToList();
        }

        public static BookTitleEntity ToEntity(this BookTitleDto bookTitleDto)
        {
            return new BookTitleEntity()
            {
                Id = bookTitleDto.Id,
                Title = bookTitleDto.Title,
                PublicationYear = bookTitleDto.PublicationYear,
                AuthorId = bookTitleDto.AuthorId
            };
        }

        public static List<BookTitleEntity> ToEntity(this IEnumerable<BookTitleDto> bookTitleDtos)
        {
            return bookTitleDtos.Select(x => x.ToEntity()).ToList();
        }

        public static BookEntity ToEntity(this BookDto bookDto)
        {
            return new BookEntity()
            {
                BookTitleId = bookDto.BookTitleId,
                EditionPublicationYear = bookDto.EditionPublicationYear,
                Condition = bookDto.Condition,
                ConditionNote = bookDto.ConditionNote
            };
        }

        public static List<BookEntity> ToEntity(this IEnumerable<BookDto> bookDtos)
        {
            return bookDtos.Select(x => x.ToEntity()).ToList();
        }

        public static BorrowEntity ToEntity(this BorrowDto borrowDto)
        {
            return new BorrowEntity()
            {
                IsActive = borrowDto.IsActive,
                BookId = borrowDto.BookId,
                ReaderId = borrowDto.ReaderId,
                BorrowDate = borrowDto.BorrowDate,
                ReturnDate = borrowDto.ReturnDate
            };
        }

        public static List<BorrowEntity> ToEntity(this IEnumerable<BorrowDto> borrowDtos)
        {
            return borrowDtos.Select(x => x.ToEntity()).ToList();
        }
    }
}
