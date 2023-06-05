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
    }
}
