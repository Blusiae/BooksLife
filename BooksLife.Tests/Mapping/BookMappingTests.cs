using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class BookMappingTests
    {
        [Fact]
        public void ToDto_ForBookEntity_ShouldReturnBookDtoWithCorrectValues()
        {
            //arrange
            var bookEntity = new BookEntity()
            {
                Id = Guid.NewGuid(),
                IsBorrowed = false,
                BookTitleId = Guid.NewGuid(),
                BookTitle = new BookTitleEntity()
                {
                    Title = "Title",
                    Author = new AuthorEntity()
                    {
                        Firstname = "Firstname",
                        Lastname = "Lastname"
                    },
                    PublicationYear = 2000
                },
                EditionPublicationYear = 2000,
                Condition = BookCondition.Fine,
                ConditionNote = "Test"
            };

            //act
            var bookDto = bookEntity.ToDto();

            //assert
            bookDto.Should().BeOfType<BookDto>();
            bookDto.Should().BeEquivalentTo(bookEntity, options => options.ExcludingMissingMembers());
            bookDto.Title.Should().Be("Title");
            bookDto.PublicationYear.Should().Be(2000);
            bookDto.AuthorName.Should().Be("Firstname Lastname");
        }

        [Fact]
        public void ToEntity_ForAddBookDto_ShouldReturnBookEntityWithCorrectValues()
        {
            //arrange
            var addBookDto = new AddBookDto()
            {
                Title = "Title",
                PublicationYear = 1999,
                AuthorId = Guid.NewGuid(),
                EditionPublicationYear = 2000,
                Condition = BookCondition.Fine,
                ConditionNote = "Test"
            };

            //act
            var bookEntity = addBookDto.ToEntity();

            //assert
            bookEntity.Should().BeOfType<BookEntity>();
            bookEntity.Should().BeEquivalentTo(addBookDto, options => options.ExcludingMissingMembers());
            bookEntity.BookTitle.Should().BeOfType<BookTitleEntity>();
            bookEntity.BookTitle.Should().BeEquivalentTo(new BookTitleEntity()
            {
                Title = "Title",
                PublicationYear = 1999,
                AuthorId = addBookDto.AuthorId
            });
        }

    }
}
