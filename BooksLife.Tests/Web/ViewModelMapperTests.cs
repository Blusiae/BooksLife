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

        [Fact]
        public void Map_ForBookTitleDto_ShouldReturnBookTitleViewModelWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var bookTitleDto = new BookTitleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Title1",
                PublicationYear = 2000,
                AuthorName = "Firstname1 Lastname1",
            };

            var bookTitleViewModel = mapper.Map(bookTitleDto);

            bookTitleViewModel.Should().BeOfType<BookTitleViewModel>();
            bookTitleViewModel.Should().BeEquivalentTo(bookTitleDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForBookTitleViewModel_ShouldReturnBookTitleDtoWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var bookTitleViewModel = new BookTitleViewModel()
            {
                Title = "Title1",
                PublicationYear = 2000,
                AuthorId = Guid.NewGuid()
            };

            var bookTitleDto = mapper.Map(bookTitleViewModel);

            bookTitleDto.Should().BeOfType<BookTitleDto>();
            bookTitleDto.Should().BeEquivalentTo(bookTitleViewModel, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfBookTitleDto_ShouldReturnListOfBookTitleViewModelWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var bookTitleDtos = new List<BookTitleDto>()
            {
                new BookTitleDto()
                {
                    Id = Guid.NewGuid(),
                    Title = "Title1",
                    PublicationYear = 2000,
                    AuthorName = "Firstname1 Lastname1",
                },
                new BookTitleDto()
                {
                    Id = Guid.NewGuid(),
                    Title = "Title2",
                    PublicationYear = 2001,
                    AuthorName = "Firstname2 Lastname2",
                }
            };

            var bookTitleViewModels = mapper.Map(bookTitleDtos);

            bookTitleViewModels.Should().BeOfType<List<BookTitleViewModel>>();
            bookTitleViewModels.Should().BeEquivalentTo(bookTitleDtos, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfBookTitleViewModel_ShouldReturnListOfBookTitleDto()
        {
            var mapper = new ViewModelMapper();
            var bookTitleViewModels = new List<BookTitleViewModel>()
            {
                new BookTitleViewModel()
                {
                    Title = "Title1",
                    PublicationYear = 2000,
                    AuthorId = Guid.NewGuid()
                },
                new BookTitleViewModel()
                {
                    Title = "Title2",
                    PublicationYear = 2001,
                    AuthorId = Guid.NewGuid()
                }
            };

            var bookTitleDtos = mapper.Map(bookTitleViewModels);

            bookTitleDtos.Should().BeOfType<List<BookTitleDto>>();
            bookTitleDtos.Should().BeEquivalentTo(bookTitleViewModels, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForBorrowDto_ShouldReturnBorrowViewModelWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var borrowDto = new BorrowDto()
            {
                IsActive = true,
                Id = Guid.NewGuid(),
                Reader = new ReaderDto(),
                Book = new BookDto(),
                BorrowDate = new DateTime(),
                ReturnDate = new DateTime()
            };

            var borrowViewModel = mapper.Map(borrowDto);

            borrowViewModel.Should().BeOfType<BorrowViewModel>();
            borrowViewModel.Reader.Should().BeOfType<ReaderViewModel>();
            borrowViewModel.Book.Should().BeOfType<BookViewModel>();
            borrowViewModel.Should().BeEquivalentTo(borrowDto, options => options.Excluding(x => x.Reader).Excluding(x => x.Book));
        }

        [Fact]
        public void Map_ForBorrowViewModel_ShouldReturnBorrowDtoWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var borrowViewModel = new BorrowViewModel()
            {
                IsActive = true,
                ReaderId = Guid.NewGuid(),
                BookId = Guid.NewGuid(),
                BorrowDate = new DateTime(),
                ReturnDate = new DateTime()
            };

            var borrowDto = mapper.Map(borrowViewModel);

            borrowDto.Should().BeOfType<BorrowDto>();
            borrowDto.Should().BeEquivalentTo(borrowDto, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void Map_ForListOfBorrowDto_ShouldReturnListOfBorrowViewModelWithCorrectValues()
        {
            var mapper = new ViewModelMapper();
            var borrowEntities = new List<BorrowDto>()
            {
                new BorrowDto()
                {
                    IsActive = true,
                    Id = Guid.NewGuid(),
                    Reader = new ReaderDto(),
                    Book = new BookDto(),
                    BorrowDate = new DateTime(),
                    ReturnDate = new DateTime()
                },
                new BorrowDto()
                {
                    IsActive = true,
                    Id = Guid.NewGuid(),
                    Reader = new ReaderDto(),
                    Book = new BookDto(),
                    BorrowDate = new DateTime(),
                    ReturnDate = new DateTime()
                }
            };

            var borrowViewModels = mapper.Map(borrowEntities);

            borrowViewModels.Should().BeOfType<List<BorrowViewModel>>();
            borrowViewModels.ElementAt(0).Reader.Should().BeOfType<ReaderViewModel>();
            borrowViewModels.ElementAt(0).Book.Should().BeOfType<BookViewModel>();
            borrowViewModels.ElementAt(0).Should().BeEquivalentTo(borrowEntities.ElementAt(0), options => options.Excluding(x => x.Reader).Excluding(x => x.Book));
            borrowViewModels.ElementAt(1).Reader.Should().BeOfType<ReaderViewModel>();
            borrowViewModels.ElementAt(1).Book.Should().BeOfType<BookViewModel>();
            borrowViewModels.ElementAt(1).Should().BeEquivalentTo(borrowEntities.ElementAt(1), options => options.Excluding(x => x.Reader).Excluding(x => x.Book));
        }

        [Fact]
        public void Map_ForListOfBorrowViewModel_ShouldReturnListOfBorrowDto()
        {
            var mapper = new ViewModelMapper();
            var borrowViewModels = new List<BorrowViewModel>()
            {
                new BorrowViewModel()
                {
                    IsActive = true,
                    ReaderId = Guid.NewGuid(),
                    BookId = Guid.NewGuid(),
                    BorrowDate = new DateTime(),
                    ReturnDate = new DateTime()
                },
                new BorrowViewModel()
                {
                    IsActive = true,
                    ReaderId = Guid.NewGuid(),
                    BookId = Guid.NewGuid(),
                    BorrowDate = new DateTime(),
                    ReturnDate = new DateTime()
                }
            };

            var borrowEntities = mapper.Map(borrowViewModels);

            borrowEntities.Should().BeOfType<List<BorrowDto>>();
            borrowEntities.Should().BeEquivalentTo(borrowViewModels, options => options.ExcludingMissingMembers());
        }
    }
}
