using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class AuthorMappingTests
    {
        [Theory]
        [InlineData("Firstname", "Lastname")]
        [InlineData(null, "Lastname")]
        public void ToDto_ForAuthorEntity_ShouldReturnAuthorDtoWithCorrectValues(string firstname, string lastname)
        {
            //arrange
            var authorEntity = new AuthorEntity()
            {
                Id = Guid.NewGuid(),
                Firstname = firstname,
                Lastname = lastname
            };

            //act
            var authorDto = authorEntity.ToDto();

            //assert
            authorDto.Should().BeOfType<AuthorDto>();
            authorDto.Should().BeEquivalentTo(authorEntity, options => options.Excluding(a => a.BookTitles));
        }

        [Theory]
        [InlineData("Firstname", "Lastname")]
        [InlineData(null, "Lastname")]
        public void ToEntity_ForAuthorDto_ShouldReturnAuthorEntityWithCorrectValues(string firstname, string lastname)
        {
            //arrange
            var authorDto = new AuthorDto()
            {
                Firstname = firstname,
                Lastname = lastname
            };

            //act
            var authorEntity = authorDto.ToEntity();

            //assert
            authorEntity.Should().BeOfType<AuthorEntity>();
            authorEntity.Should().BeEquivalentTo(authorDto);
        }

    }
}
