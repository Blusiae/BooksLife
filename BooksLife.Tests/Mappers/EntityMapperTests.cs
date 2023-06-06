using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class EntityMapperTests
    {

        [Fact]
        public void ForAuthorDto_ShouldReturnAuthorEntityWithCorrectValues()
        {
            var authorDto = new AuthorDto()
            {
                Firstname = "AuthorFirstname",
                Lastname = "AuthorLastname"
            };

            var authorEntity = authorDto.ToEntity();

            authorEntity.Should().BeOfType<AuthorEntity>();
            authorEntity.Should().BeEquivalentTo(authorDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForCollectionOfAuthorDto_ShouldReturnListOfAuthorEntityWithCorrectValues()
        {
            var authorDtos = new List<AuthorDto>()
            {
                new AuthorDto()
                {
                    Firstname = "AuthorFirstname1",
                    Lastname = "AuthorLastname1"
                },
                new AuthorDto()
                {
                    Firstname = "AuthorFirstname2",
                    Lastname = "AuthorLastname2"
                }
            };

            var authorEntities = authorDtos.ToEntity();

            authorEntities.Should().BeOfType<List<AuthorEntity>>();
            authorEntities.Should().BeEquivalentTo(authorDtos, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForReaderDto_ShouldReturnReaderEntityWithCorrectValues()
        {
            var readerDto = new ReaderDto()
            {
                Firstname = "ReaderFirstname",
                Lastname = "ReaderLastname",
                Birthdate = DateTime.Now,
                EmailAddress = "email@address.com",
                PhoneNumber = "123456789",
                Country = "AddressCountry",
                City = "AddressCity",
                PostalCode = "12345",
                Street = "AddressStreet",
                HouseNumber = "22b",
                FlatNumber = "1"
            };

            var readerEntity = readerDto.ToEntity();

            readerEntity.Should().BeOfType<ReaderEntity>();
            readerEntity.Should().BeEquivalentTo(readerDto, options => options.ExcludingMissingMembers());
            readerEntity.Address.Should().BeEquivalentTo(new AddressEntity()
            {
                Country = "AddressCountry",
                City = "AddressCity",
                PostalCode = "12345",
                Street = "AddressStreet",
                HouseNumber = "22b",
                FlatNumber = "1"
            }, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForCollectionOfReaderDto_ShouldReturnListOfReaderEntityWithCorrectValues()
        {
            var readerDtos = new List<ReaderDto>()
            {
                new ReaderDto()
                {
                    Firstname = "ReaderFirstname",
                    Lastname = "ReaderLastname",
                    Birthdate = DateTime.Now,
                    EmailAddress = "email@address.com",
                    PhoneNumber = "123456789",
                    Country = "AddressCountry",
                    City = "AddressCity",
                    PostalCode = "12345",
                    Street = "AddressStreet",
                    HouseNumber = "22b",
                    FlatNumber = "1"
                },
                new ReaderDto()
                {
                    Firstname = "ReaderFirstname",
                    Lastname = "ReaderLastname",
                    Birthdate = DateTime.Now,
                    EmailAddress = "email@address.com",
                    PhoneNumber = "123456789",
                    Country = "AddressCountry",
                    City = "AddressCity",
                    PostalCode = "12345",
                    Street = "AddressStreet",
                    HouseNumber = "22b",
                    FlatNumber = "1"
                }
            };

            var readerEntities = readerDtos.ToEntity();

            readerEntities.Should().BeOfType<List<ReaderEntity>>();
            readerEntities.Should().BeEquivalentTo(readerDtos, options => options.ExcludingMissingMembers());
            foreach (var readerEntity in readerEntities) 
            {
                readerEntity.Address.Should().BeEquivalentTo(new AddressEntity()
                {
                    Country = "AddressCountry",
                    City = "AddressCity",
                    PostalCode = "12345",
                    Street = "AddressStreet",
                    HouseNumber = "22b",
                    FlatNumber = "1"
                }, options => options.ExcludingMissingMembers());
            }
        }

        [Fact]
        public void ForBookTitleDto_ShouldReturnBookTitleEntityWithCorrectValues()
        {
            var bookTitleDto = new BookTitleDto()
            {
                Title = "BookTitle",
                PublicationYear = 2000,
                AuthorId = Guid.NewGuid()
            };

            var bookTitleEntity = bookTitleDto.ToEntity();

            bookTitleEntity.Should().BeOfType<BookTitleEntity>();
            bookTitleEntity.Should().BeEquivalentTo(bookTitleDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForCollectionOfBookTitleDto_ShouldReturnListOfBookTitleEntityWithCorrectValues()
        {
            var bookTitleDtos = new List<BookTitleDto>()
            {
                new BookTitleDto()
                {
                    Title = "BookTitle",
                    PublicationYear = 2000,
                    AuthorId = Guid.NewGuid()
                },
                new BookTitleDto()
                {
                    Title = "BookTitle",
                    PublicationYear = 2000,
                    AuthorId = Guid.NewGuid()
                }
            };

            var bookTitleEntities = bookTitleDtos.ToEntity();

            bookTitleEntities.Should().BeOfType<List<BookTitleEntity>>();
            bookTitleEntities.Should().BeEquivalentTo(bookTitleDtos, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForBookDto_ShouldReturnBookEntityWithCorrectValues()
        {
            var bookDto = new BookDto()
            {
                BookTitleId = Guid.NewGuid(),
                EditionPublicationYear = 2000,
                Condition = BookCondition.Fine,
                ConditionNote = "Condition"
            };

            var bookEntity = bookDto.ToEntity();

            bookEntity.Should().BeOfType<BookEntity>();
            bookEntity.Should().BeEquivalentTo(bookDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForCollectionOfBookDto_ShouldReturnListOfBookEntity()
        {
            var bookDtos = new List<BookDto>()
            {
                new BookDto()
                {
                    BookTitleId = Guid.NewGuid(),
                    EditionPublicationYear = 2000,
                    Condition = BookCondition.Fine,
                    ConditionNote = "Condition"
                },
                new BookDto()
                {
                    BookTitleId = Guid.NewGuid(),
                    EditionPublicationYear = 2000,
                    Condition = BookCondition.Fine,
                    ConditionNote = "Condition"
                }
            };

            var bookEntities = bookDtos.ToEntity();

            bookEntities.Should().BeOfType<List<BookEntity>>();
            bookEntities.Should().BeEquivalentTo(bookDtos, options => options.ExcludingMissingMembers());
        }
    }
}
