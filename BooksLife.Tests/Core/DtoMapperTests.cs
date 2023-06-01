using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class DtoMapperTests
    {
        [Fact]
        public void Map_ForAuthorEntityObject_ShouldReturnAuthorDtoObjectWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorEntity = new AuthorEntity { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorDto = mapper.Map(authorEntity);

            authorDto.Should().BeOfType<AuthorDto>();
            authorDto.Should().BeEquivalentTo(authorEntity, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForAuthorDtoObject_ShouldReturnAuthorEntityObjectWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorDto = new AuthorDto{ Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorEntity = mapper.Map(authorDto);

            authorEntity.Should().BeOfType<AuthorEntity>();
            authorEntity.Should().BeEquivalentTo(authorDto);
        }

        [Fact]
        public void Map_ForListOfAuthorEntityObjects_ShouldReturnListOfAuthorDtoObjectsWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorEntities = new List<AuthorEntity>()
            {
                new AuthorEntity { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorEntity { Id = Guid.NewGuid(), Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorEntity { Id = Guid.NewGuid(), Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorDtos = mapper.Map(authorEntities);

            authorDtos.Should().BeOfType<List<AuthorDto>>();
            authorDtos.Should().BeEquivalentTo(authorEntities, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfAuthorDtoObjects_ShouldReturnListOfAuthorEntityObjectsWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorDtos = new List<AuthorDto>()
            {
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorEntities = mapper.Map(authorDtos);

            authorEntities.Should().BeOfType<List<AuthorEntity>>();
            authorEntities.Should().BeEquivalentTo(authorDtos);
        }

        [Fact]
        public void Map_ForReaderEntity_ShouldReturnReaderDtoWithCorrectPropertiesAndAddressIncluded()
        {
            var mapper = new DtoMapper();
            var readerEntity = new ReaderEntity()
            {
                Id = Guid.NewGuid(),
                Firstname = "Firstname1",
                Lastname = "Lastname1",
                Birthdate = new DateTime(2000, 10, 11),
                EmailAddress = "email.address@email.com"
            };
            var addressEntity = new AddressEntity()
            {
                Id = Guid.NewGuid(),
                Country = "Poland",
                City = "Warsaw"
            };
            readerEntity.Address = addressEntity;
            readerEntity.AddressId = addressEntity.Id;

            var readerDto = mapper.Map(readerEntity);

            readerDto.Should().BeOfType<ReaderDto>();
            readerDto.Should().BeEquivalentTo(readerEntity, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForReaderDto_ShouldReturnReaderEntityWithCorrectPropertiesAndAddressIncluded()
        {
            var mapper = new DtoMapper();
            var readerDto = new ReaderDto()
            {
                Firstname = "Firstname1",
                Lastname = "Lastname1",
                Birthdate = new DateTime(2000, 10, 11),
                EmailAddress = "email.address@email.com",
                PhoneNumber = "+48999999999",
                Country = "Poland",
                City = "Warsaw"
            };

            var readerEntity = mapper.Map(readerDto);

            readerEntity.Should().BeOfType<ReaderEntity>();
            readerEntity.Should().BeEquivalentTo(readerDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfReaderEntities_ShouldReturnListOfReaderDtosWithCorrectPropertiesAndAddressesIncluded()
        {
            var mapper = new DtoMapper();
            var addressEntity = new AddressEntity()
            {
                Id = new Guid(),
                Country = "Poland",
                City = "Warsaw"
            };
            var readerEntities = new List<ReaderEntity>()
            {
                new ReaderEntity(){Id = new Guid(), Firstname = "Firstname 1", Lastname = "Lastname 1", Address = addressEntity, AddressId = addressEntity.Id},
                new ReaderEntity(){Id = new Guid(), Firstname = "Firstname 2", Lastname = "Lastname 2", Address = addressEntity, AddressId = addressEntity.Id}
            };

            var readerDtos = mapper.Map(readerEntities);

            readerDtos.Should().BeOfType<List<ReaderDto>>();
            readerDtos.Should().BeEquivalentTo(readerEntities, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfReaderDtos_ShouldReturnListOfReaderEntitiesWithCorrectPropertiesAndAddressesIncluded()
        {
            var mapper = new DtoMapper();
            var readerDtos = new List<ReaderDto>()
            {
                new ReaderDto(){Firstname = "Firstname 1", Lastname = "Lastname 1", Country = "Poland"},
                new ReaderDto(){Firstname = "Firstname 2", Lastname = "Lastname 2", Country = "Poland"}
            };

            var readerEntities = mapper.Map(readerDtos);

            readerEntities.Should().BeOfType<List<ReaderEntity>>();
            readerEntities.Should().BeEquivalentTo(readerDtos, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForBookEntity_ShouldReturnBookDtoWithCorrectValues()
        {
            var mapper = new DtoMapper();
            var bookEntity = new BookEntity()
            {
                Id = Guid.NewGuid(),
                BookTitle = new BookTitleEntity()
                {
                    Id = Guid.NewGuid(),
                    Title = "Title",
                    PublicationYear = 2000,
                    Author = new AuthorEntity()
                    {
                        Firstname = "Firstname",
                        Lastname = "Lastname"
                    }
                },
                EditionPublicationYear = 2001,
                Condition = BookCondition.Fair,
                ConditionNote = "First page is missing."
            };

            var bookDto = mapper.Map(bookEntity);

            bookDto.Should().BeOfType<BookDto>();
            bookDto.AuthorName.Should().Be("Firstname Lastname");
            bookDto.Title.Should().Be(bookEntity.BookTitle.Title);
            bookDto.PublicationYear.Should().Be(bookEntity.BookTitle.PublicationYear);
            bookDto.Should().BeEquivalentTo(bookEntity, options => options
                .Excluding(x => x.BookTitle)
                .ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForBookDto_ShouldReturnBookEntityWithCorrectValues()
        {
            var mapper = new DtoMapper();
            var bookDto = new BookDto()
            {
                BookTitleId = Guid.NewGuid(),
                EditionPublicationYear = 2001,
                Condition = BookCondition.Good
            };

            var bookEntity = mapper.Map(bookDto);

            bookEntity.Should().BeOfType<BookEntity>();
            bookEntity.Should().BeEquivalentTo(bookDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfBookEntity_ShouldReturnListOfBookDtoWithCorrectValues()
        {
            var mapper = new DtoMapper();
            var bookEntities = new List<BookEntity>()
            {
                new BookEntity()
                {
                    Id = Guid.NewGuid(),
                    BookTitle = new BookTitleEntity()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Title",
                        PublicationYear = 2000,
                        Author = new AuthorEntity()
                        {
                            Firstname = "Firstname",
                            Lastname = "Lastname"
                        }
                    },
                    EditionPublicationYear = 2001,
                    Condition = BookCondition.Fair,
                    ConditionNote = "First page is missing."
                },
                new BookEntity()
                {
                    Id = Guid.NewGuid(),
                    BookTitle = new BookTitleEntity()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Title2",
                        PublicationYear = 2001,
                        Author = new AuthorEntity()
                        {
                            Firstname = "Firstname",
                            Lastname = "Lastname"
                        }
                    },
                    EditionPublicationYear = 2001,
                    Condition = BookCondition.Poor,
                    ConditionNote = "First and second pages are missing."
                }
            };

            var bookDtos = mapper.Map(bookEntities);

            bookDtos.Should().BeOfType<List<BookDto>>();
            bookDtos.ElementAt(0).AuthorName.Should().Be("Firstname Lastname");
            bookDtos.ElementAt(0).Title.Should().Be(bookEntities.ElementAt(0).BookTitle.Title);
            bookDtos.ElementAt(0).PublicationYear.Should().Be(bookEntities.ElementAt(0).BookTitle.PublicationYear);
            bookDtos.ElementAt(0).Should().BeEquivalentTo(bookEntities.ElementAt(0), options => options
                .Excluding(x => x.BookTitle)
                .ExcludingMissingMembers());
            bookDtos.ElementAt(1).AuthorName.Should().Be("Firstname Lastname");
            bookDtos.ElementAt(1).Title.Should().Be(bookEntities.ElementAt(1).BookTitle.Title);
            bookDtos.ElementAt(1).PublicationYear.Should().Be(bookEntities.ElementAt(1).BookTitle.PublicationYear);
            bookDtos.ElementAt(1).Should().BeEquivalentTo(bookEntities.ElementAt(1), options => options
                .Excluding(x => x.BookTitle)
                .ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfBookDto_ShouldReturnListOfBookEntityWithCorrectValues()
        {
            var mapper = new DtoMapper();
            var bookDtos = new List<BookDto>()
            {
                new BookDto()
                {
                    BookTitleId = Guid.NewGuid(),
                    EditionPublicationYear = 2001,
                    Condition = BookCondition.Good
                },
                new BookDto()
                {
                    BookTitleId = Guid.NewGuid(),
                    EditionPublicationYear = 2002,
                    Condition = BookCondition.Poor
                },
            };

            var bookEntities = mapper.Map(bookDtos);

            bookEntities.Should().BeOfType<List<BookEntity>>();
            bookEntities.Should().BeEquivalentTo(bookDtos, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForBookTitleEntity_ShouldReturnBookTitleDtoWithCorrectValues()
        {
            var mapper = new DtoMapper();
            var bookTitleEntity = new BookTitleEntity()
            {
                Id = Guid.NewGuid(),
                Title = "Title1",
                PublicationYear = 2000,
                Author = new AuthorEntity()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Firstname",
                    Lastname = "Lastname"
                }
            };

            var bookTitleDto = mapper.Map(bookTitleEntity);

            bookTitleDto.Should().BeOfType<BookTitleDto>();
            bookTitleDto.Should().BeEquivalentTo(bookTitleEntity, options => options.ExcludingMissingMembers());
            bookTitleDto.AuthorName.Should().Be("Firstname Lastname");
        }

        [Fact]
        public void Map_ForBookTitleDto_ShouldReturnBookTitleEntityWithCorrectValues()
        {
            var mapper = new DtoMapper();
            var bookTitleDto = new BookTitleDto()
            {
                Title = "Title1",
                PublicationYear = 2000,
                AuthorId = Guid.NewGuid()
            };

            var bookTitleEntity = mapper.Map(bookTitleDto);

            bookTitleEntity.Should().BeOfType<BookTitleEntity>();
            bookTitleEntity.Should().BeEquivalentTo(bookTitleDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfBookTitleEntity_ShouldReturnListOfBookTitleDtoWithCorrectValues()
        {
            var mapper = new DtoMapper();
            var bookTitleEntities = new List<BookTitleEntity>()
            {
                new BookTitleEntity()
                {
                    Id = Guid.NewGuid(),
                    Title = "Title1",
                    PublicationYear = 2000,
                    Author = new AuthorEntity()
                    {
                        Id = Guid.NewGuid(),
                        Firstname = "Firstname",
                        Lastname = "Lastname"
                    }
                },
                new BookTitleEntity()
                {
                    Id = Guid.NewGuid(),
                    Title = "Title2",
                    PublicationYear = 2001,
                    Author = new AuthorEntity()
                    {
                        Id = Guid.NewGuid(),
                        Firstname = "Firstname2",
                        Lastname = "Lastname2"
                    }
                }
            };

            var bookTitleDtos = mapper.Map(bookTitleEntities);

            bookTitleDtos.Should().BeOfType<List<BookTitleDto>>();
            bookTitleDtos.Should().BeEquivalentTo(bookTitleEntities, options => options.ExcludingMissingMembers());
            bookTitleDtos.ElementAt(0).AuthorName.Should().Be("Firstname Lastname");
            bookTitleDtos.ElementAt(1).AuthorName.Should().Be("Firstname2 Lastname2");
        }

        [Fact]
        public void Map_ForListOfBookTitleDto_ShouldReturnListOfBookTitleEntityWithCorrectValues()
        {
            var mapper = new DtoMapper();
            var bookTitleDtos = new List<BookTitleDto>()
            {
                new BookTitleDto()
                {
                    Title = "Title1",
                    PublicationYear = 2000,
                    AuthorId = Guid.NewGuid()
                },
                new BookTitleDto()
                {
                    Title = "Title2",
                    PublicationYear = 2002,
                    AuthorId = Guid.NewGuid()
                }
            };

            var bookTitleEntities = mapper.Map(bookTitleDtos);

            bookTitleEntities.Should().BeOfType<List<BookTitleEntity>>();
            bookTitleEntities.Should().BeEquivalentTo(bookTitleDtos, options => options.ExcludingMissingMembers());
        }
    }
}
