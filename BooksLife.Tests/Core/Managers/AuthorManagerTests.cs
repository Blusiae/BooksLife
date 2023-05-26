using BooksLife.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace BooksLife.Tests
{
    public class AuthorManagerTests
    {
        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new author has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Author has been removed.";
        [Theory]
        [InlineData(true, SUCCEED_ADD_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Add_ForResponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var authorRepositoryMock = new Mock<IAuthorRepository>();
            authorRepositoryMock.Setup(m => m.Add(It.IsAny<AuthorEntity>())).Returns(dbResponse);
            var dtoMapperMock = new Mock<IDtoMapper>();
            dtoMapperMock.Setup(m => m.Map(It.IsAny<AuthorDto>())).Returns(new AuthorEntity());
            var authorManager = new AuthorManager(authorRepositoryMock.Object, dtoMapperMock.Object);

            var result = authorManager.Add(new AuthorDto());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }

        [Theory]
        [InlineData(true, SUCCEED_REMOVE_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Remove_ForReponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var authorRepositoryMock = new Mock<IAuthorRepository>();
            authorRepositoryMock.Setup(m => m.Remove(It.IsAny<int>())).Returns(dbResponse);
            var authorManager = new AuthorManager(authorRepositoryMock.Object);

            var result = authorManager.Remove(0);

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }
    }
}
