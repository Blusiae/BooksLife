using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class ViewModelMapperTests
    {
        [Fact]
        public void Map_ForAuthorViewModelObject_ShouldReturnAuthorDtoObjectWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var authorViewModel = new AuthorViewModel { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorDto = mapper.Map(authorViewModel);

            authorDto.Should().BeOfType<AuthorDto>();
            authorDto.Should().BeEquivalentTo(authorViewModel);
        }

        [Fact]
        public void Map_ForAuthorDtoObject_ShouldReturnAuthorViewModelObjectWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var authorDto = new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorViewModel = mapper.Map(authorDto);

            authorViewModel.Should().BeOfType<AuthorViewModel>();
            authorViewModel.Should().BeEquivalentTo(authorDto);
        }

        [Fact]
        public void Map_ForListOfAuthorViewModelObjects_ShouldReturnListOfAuthorDtoObjectsWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var authorViewModels = new List<AuthorViewModel>()
            {
                new AuthorViewModel { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorViewModel { Id = Guid.NewGuid(), Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorViewModel { Id = Guid.NewGuid(), Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorDtos = mapper.Map(authorViewModels);

            authorDtos.Should().BeOfType<List<AuthorDto>>();
            authorDtos.Should().BeEquivalentTo(authorViewModels);
        }

        [Fact]
        public void Map_ForListOfAuthorDtoObjects_ShouldReturnListOfAuthorViewModelObjectsWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var authorDtos = new List<AuthorDto>()
            {
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorDto { Id = Guid.NewGuid(), Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorViewModels = mapper.Map(authorDtos);

            authorViewModels.Should().BeOfType<List<AuthorViewModel>>();
            authorViewModels.Should().BeEquivalentTo(authorDtos);
        }

        [Fact]
        public void Map_ForReaderViewModel_ShouldReturnReaderDtoWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var readerViewModel = new ReaderViewModel()
            {
                Firstname = "Firstname1",
                Lastname = "Lastname1",
                EmailAddress = "email@address.com",
                Country = "Poland",
                City = "Warsaw"
            };

            var readerDto = mapper.Map(readerViewModel);

            readerDto.Should().BeOfType<ReaderDto>();
            readerDto.Should().BeEquivalentTo(readerViewModel);
        }

        [Fact]
        public void Map_ForListOfReaderViewModels_ShouldReturnListOfReaderDtosWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var readerViewModels = new List<ReaderViewModel>()
            {
                new ReaderViewModel()
                {
                    Firstname = "Firstname1",
                    Lastname = "Lastname1",
                    EmailAddress = "email@address.com",
                    Country = "Poland",
                    City = "Warsaw"
                },
                new ReaderViewModel()
                {
                    Firstname = "Firstname2",
                    Lastname = "Lastname2",
                    EmailAddress = "emai2l@address.com",
                    Country = "Poland",
                    City = "Katowice"

                }
            };

            var readerDtos = mapper.Map(readerViewModels);

            readerDtos.Should().BeOfType<List<ReaderDto>>();
            readerDtos.Should().BeEquivalentTo(readerViewModels);
        }

        [Fact]
        public void Map_ForReaderDto_ShouldReturnReaderViewModelWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var readerDto = new ReaderDto()
            {
                Id = Guid.NewGuid(),
                Firstname = "Firstname1",
                Lastname = "Lastname1",
                EmailAddress = "email@address.com",
                Country = "Poland",
                City = "Warsaw",
                Street = "Flower St",
                HouseNumber = "22a",
                FlatNumber = "20",
                PostalCode = "00-000"
            };

            var readerViewModel = mapper.Map(readerDto);

            readerViewModel.Should().BeOfType<ReaderViewModel>();
            readerViewModel.Should().BeEquivalentTo(readerDto, options => options.ExcludingMissingMembers().Excluding(x => x.PhoneNumber));
            readerViewModel.PhoneNumber.Should().Be("-");
        }

        [Fact]
        public void Map_ForListOfReaderDto_ShouldReturnListOfReaderViewModelsWithCorrectProperties()
        {
            var mapper = new ViewModelMapper();
            var readerDtos = new List<ReaderDto>()
            {
                new ReaderDto()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Firstname1",
                    Lastname = "Lastname1",
                    PhoneNumber = "1234567890",
                    Country = "Poland",
                    City = "Warsaw",
                    Street = "Flower St",
                    HouseNumber = "22a",
                    FlatNumber = "20",
                    PostalCode = "00-000"

                },
                new ReaderDto()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Firstname2",
                    Lastname = "Lastname2",
                    EmailAddress = "emai2l@address.com",
                    PhoneNumber= "1234567890",
                    Country = "Poland",
                    City = "Katowice",
                    Street = "Flower St",
                    HouseNumber = "22a",
                    FlatNumber = "20",
                    PostalCode = "00-000"
                }
            };

            var readerViewModels = mapper.Map(readerDtos);

            readerViewModels.Should().BeOfType<List<ReaderViewModel>>();
            readerViewModels.Should().BeEquivalentTo(readerDtos, options => options.ExcludingMissingMembers().Excluding(x => x.EmailAddress));
            readerViewModels.ElementAt(0).EmailAddress.Should().Be("-");
            readerViewModels.ElementAt(1).EmailAddress.Should().Be("emai2l@address.com");
        }

        [Fact]
        public void Map_ForBookDto_ShouldReturnBookViewModelWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var bookDto = new BookDto()
            {
                Id = Guid.NewGuid(),
                Title = "Title1",
                PublicationYear = 2000,
                EditionPublicationYear = 2001,
                AuthorName = "Firstname1 Lastname1",
                Condition = BookCondition.Good
            };

            var bookViewModel = mapper.Map(bookDto);

            bookViewModel.Should().BeOfType<BookViewModel>();
            bookViewModel.Should().BeEquivalentTo(bookDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForBookViewModel_ShouldReturnBookDtoWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var bookViewModel = new BookViewModel()
            {
                BookTitleId = Guid.NewGuid(),
                PublicationYear = 2000,
                Condition = BookCondition.Poor,
                ConditionNote = "Two pages are missing.",
                AuthorId = Guid.NewGuid()
            };

            var bookDto = mapper.Map(bookViewModel);

            bookDto.Should().BeOfType<BookDto>();
            bookDto.Should().BeEquivalentTo(bookViewModel, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfBookDto_ShouldReturnListOfBookViewModelWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var bookDtos = new List<BookDto>()
            {
                new BookDto()
                {
                    Id = Guid.NewGuid(),
                    Title = "Title1",
                    PublicationYear = 2000,
                    EditionPublicationYear = 2001,
                    AuthorName = "Firstname1 Lastname1",
                    Condition = BookCondition.Good
                },
                new BookDto()
                {
                    Id = Guid.NewGuid(),
                    Title = "Title2",
                    PublicationYear = 2001,
                    EditionPublicationYear = 2002,
                    AuthorName = "Firstname2 Lastname2",
                    Condition = BookCondition.Good
                }
            };

            var bookViewModels = mapper.Map(bookDtos);

            bookViewModels.Should().BeOfType<List<BookViewModel>>();
            bookViewModels.Should().BeEquivalentTo(bookDtos, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfBookViewModel_ShouldReturnListOfBookDto()
        {
            var mapper = new ViewModelMapper();
            var bookViewModels = new List<BookViewModel>()
            {
                new BookViewModel()
                {
                    BookTitleId = Guid.NewGuid(),
                    PublicationYear = 2000,
                    Condition = BookCondition.Poor,
                    ConditionNote = "Two pages are missing.",
                    AuthorId = Guid.NewGuid()
                },
                new BookViewModel()
                {
                    BookTitleId = Guid.NewGuid(),
                    PublicationYear = 2001,
                    Condition = BookCondition.Poor,
                    ConditionNote = "Three pages are missing.",
                    AuthorId = Guid.NewGuid()
                }
            };

            var bookDtos = mapper.Map(bookViewModels);

            bookDtos.Should().BeOfType<List<BookDto>>();
            bookDtos.Should().BeEquivalentTo(bookViewModels, options => options.ExcludingMissingMembers());
        }
    }
}
