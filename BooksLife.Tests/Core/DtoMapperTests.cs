using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class DtoMapperTests
    {
        [Fact]
        public void ForAuthorEntity_ShouldReturnAuthorDtoWithCorrectValues()
        {
            var authorEntity = new AuthorEntity()
            {
                Id = Guid.NewGuid(),
                Firstname = "AuthorFirstname",
                Lastname = "AuthorLastname"
            };

            var authorDto = authorEntity.ToDto();

            authorDto.Should().BeOfType<AuthorDto>();
            authorDto.Should().BeEquivalentTo(authorEntity, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForCollectionOfAuthorEntity_ShouldReturnListOfAuthorDtoWithCorrectValues()
        {
            var authorEntities = new List<AuthorEntity>()
            {
                new AuthorEntity()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "AuthorFirstname1",
                    Lastname = "AuthorLastname1"
                },
                new AuthorEntity()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "AuthorFirstname2",
                    Lastname = "AuthorLastname2"
                }
            };

            var authorDtos = authorEntities.ToDto();

            authorDtos.Should().BeOfType<List<AuthorDto>>();
            authorDtos.Should().BeEquivalentTo(authorEntities, options => options.ExcludingMissingMembers());
        }
    }
}
