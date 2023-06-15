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
    }
}
