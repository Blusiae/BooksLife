using BooksLife.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace BooksLife.Tests 
{ 
    public class ReaderManagerTests
    {
        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new reader has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Reader has been removed.";

        [Theory]
        [InlineData(true, SUCCEED_ADD_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Add_ForResponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var readerRepositoryMock = new Mock<IReaderRepository>();
            readerRepositoryMock.Setup(m => m.Add(It.IsAny<ReaderEntity>())).Returns(dbResponse);
            var readerManager = new ReaderManager(readerRepositoryMock.Object);

            var result = readerManager.Add(new AddReaderDto());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }

        [Theory]
        [InlineData(true, SUCCEED_REMOVE_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Remove_ForReponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var readerRepositoryMock = new Mock<IReaderRepository>();
            readerRepositoryMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(dbResponse);
            var readerManager = new ReaderManager(readerRepositoryMock.Object);

            var result = readerManager.Remove(Guid.NewGuid());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }
    }
}
