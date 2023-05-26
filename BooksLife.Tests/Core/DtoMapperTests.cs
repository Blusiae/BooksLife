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
            var authorEntity = new AuthorEntity { Id = 1, Firstname = "Firstname1", Lastname = "Lastname1" };

            var authorDto = mapper.Map(authorEntity);

            authorDto.Should().BeOfType<AuthorDto>();
            authorDto.Should().BeEquivalentTo(authorEntity);
        }

        [Fact]
        public void Map_ForAuthorDtoObject_ShouldReturnAuthorEntityObjectWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorDto = new AuthorDto{ Id = 1, Firstname = "Firstname1", Lastname = "Lastname1" };

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
                new AuthorEntity { Id = 1, Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorEntity { Id = 2, Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorEntity { Id = 3, Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorDtos = mapper.Map(authorEntities);

            authorDtos.Should().BeOfType<IEnumerable<AuthorDto>>();
            authorDtos.Should().BeEquivalentTo(authorEntities);
        }

        [Fact]
        public void Map_ForListOfAuthorDtoObjects_ShouldReturnListOfAuthorEntityObjectsWithCorrectProperties()
        {
            var mapper = new DtoMapper();
            var authorDtos = new List<AuthorDto>()
            {
                new AuthorDto { Id = 1, Firstname = "Firstname1", Lastname = "Lastname1" },
                new AuthorDto { Id = 2, Firstname = "Firstname2", Lastname = "Lastname2" },
                new AuthorDto { Id = 3, Firstname = "Firstname3", Lastname = "Lastname2" }
            };

            var authorEntities = mapper.Map(authorDtos);

            authorEntities.Should().BeOfType<IEnumerable<AuthorEntity>>();
            authorEntities.Should().BeEquivalentTo(authorDtos);
        }
    }
}
