﻿namespace BooksLife.Core
{
    public static class DtoMapExtensions
    {
       public static AuthorDto ToDto(this AuthorEntity authorEntity)
        {
            return new AuthorDto()
            {
                Id = authorEntity.Id,
                Firstname = authorEntity.Firstname,
                Lastname = authorEntity.Lastname
            };
        }

        public static List<AuthorDto> ToDto(this IEnumerable<AuthorEntity> authorEntities)
        {
            return authorEntities.Select(x => x.ToDto()).ToList();
        }

        public static ReaderDto ToDto(this ReaderEntity readerEntity)
        {
            return new ReaderDto()
            {
                Id = readerEntity.Id,
                Firstname = readerEntity.Firstname,
                Lastname = readerEntity.Lastname,
                Birthdate = readerEntity.Birthdate,
                EmailAddress = readerEntity.EmailAddress,
                PhoneNumber = readerEntity.PhoneNumber,
                Country = readerEntity.Address.Country,
                City = readerEntity.Address.City,
                PostalCode = readerEntity.Address.PostalCode,
                Street = readerEntity.Address.Street,
                HouseNumber = readerEntity.Address.HouseNumber,
                FlatNumber = readerEntity.Address.FlatNumber
            };
        }

        public static List<ReaderDto> ToDto(this IEnumerable<ReaderEntity> readerEntities)
        {
            return readerEntities.Select(x => x.ToDto()).ToList();
        }

        public static BookTitleDto ToDto(this BookTitleEntity bookTitleEntity)
        {
            return new BookTitleDto()
            {
                Id = bookTitleEntity.Id,
                Title = bookTitleEntity.Title,
                PublicationYear = bookTitleEntity.PublicationYear,
                AuthorId = bookTitleEntity.AuthorId,
                AuthorName = $"{bookTitleEntity.Author.Firstname} {bookTitleEntity.Author.Lastname}"
            };
        }

        public static List<BookTitleDto> ToDto(this IEnumerable<BookTitleEntity> bookTitleEntities) 
        {
            return bookTitleEntities.Select(x => x.ToDto()).ToList();
        }

        public static BookDto ToDto(this BookEntity bookEntity)
        {
            return new BookDto()
            {
                Id = bookEntity.Id,
                IsBorrowed = bookEntity.IsBorrowed,
                Title = bookEntity.BookTitle.Title,
                PublicationYear = bookEntity.BookTitle.PublicationYear,
                EditionPublicationYear = bookEntity.EditionPublicationYear,
                AuthorName = $"{bookEntity.BookTitle.Author.Firstname} {bookEntity.BookTitle.Author.Lastname}",
                Condition = bookEntity.Condition,
                ConditionNote = bookEntity.ConditionNote
            };
        }

        public static List<BookDto> ToDto(this IEnumerable<BookEntity> bookEntities)
        {
            return bookEntities.Select(x => x.ToDto()).ToList();
        }
    }
}
