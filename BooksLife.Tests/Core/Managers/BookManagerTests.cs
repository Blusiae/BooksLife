using BooksLife.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace BooksLife.Tests
{
    public class BookManagerTests
    {
        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new book has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Book has been removed.";
        [Theory]
        [InlineData(true, SUCCEED_ADD_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Add_ForResponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(m => m.Add(It.IsAny<BookEntity>())).Returns(dbResponse);
            var bookManager = new BookManager(bookRepositoryMock.Object);

            var result = bookManager.Add(new BookDto());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }

        [Theory]
        [InlineData(true, SUCCEED_REMOVE_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Remove_ForReponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(dbResponse);
            var bookManager = new BookManager(bookRepositoryMock.Object);

            var result = bookManager.Remove(Guid.NewGuid());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }
    }
}
