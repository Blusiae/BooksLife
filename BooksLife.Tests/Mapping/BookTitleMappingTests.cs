using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BookTitlesLife.Tests
{
    public class BookTitleTitleMappingTests
    {
        [Fact]
        public void ToDto_ForBookTitleEntity_ShouldReturnBookTitleDtoWithCorrectValues()
        {
            //arrange
            var bookTitleEntity = new BookTitleEntity()
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                PublicationYear = 2000,
                AuthorId = Guid.NewGuid(),
                Author = new AuthorEntity()
                {
                    Firstname = "Firstname",
                    Lastname = "Lastname"
                }
            };

            //act
            var bookTitleDto = bookTitleEntity.ToDto();

            //assert
            bookTitleDto.Should().BeOfType<BookTitleDto>();
            bookTitleDto.Should().BeEquivalentTo(bookTitleEntity, options => options.ExcludingMissingMembers());
            bookTitleDto.AuthorName.Should().Be("Firstname Lastname");
        }

        [Fact]
        public void ToEntity_ForAddBookTitleDto_ShouldReturnBookTitleEntityWithCorrectValues()
        {
            //arrange
            var addBookTitleDto = new AddBookTitleDto()
            {
                Title = "Test",
                PublicationYear = 2000,
                AuthorId = Guid.NewGuid()
            };

            //act
            var bookEntity = addBookTitleDto.ToEntity();

            //assert
            bookEntity.Should().BeOfType<BookTitleEntity>();
            bookEntity.Should().BeEquivalentTo(addBookTitleDto, options => options.ExcludingMissingMembers());
        }

    }
}
