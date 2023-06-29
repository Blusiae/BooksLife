using BooksLife.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace BooksLife.Tests
{
    public class BookTitleManagerTests
    {
        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new book title has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Book title has been removed.";
        [Theory]
        [InlineData(true, SUCCEED_ADD_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Add_ForResponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var bookTitleRepositoryMock = new Mock<IBookTitleRepository>();
            bookTitleRepositoryMock.Setup(m => m.Add(It.IsAny<BookTitleEntity>())).Returns(dbResponse);
            var bookTitleManager = new BookTitleManager(bookTitleRepositoryMock.Object);

            var result = bookTitleManager.Add(new AddBookTitleDto());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }

        [Theory]
        [InlineData(true, SUCCEED_REMOVE_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Remove_ForReponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var bookTitleRepositoryMock = new Mock<IBookTitleRepository>();
            bookTitleRepositoryMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(dbResponse);
            var bookTitleManager = new BookTitleManager(bookTitleRepositoryMock.Object);

            var result = bookTitleManager.Remove(Guid.NewGuid());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }
    }
}
