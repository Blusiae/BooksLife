﻿using BooksLife.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace BooksLife.Tests
{
    public class BorrowManagerTests
    {
        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new borrow has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Borrow has been removed.";
        private const string SUCCED_RETURNED_MESSAGE = "Marked borrow as returned.";
        [Theory]
        [InlineData(true, SUCCEED_ADD_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Add_ForResponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var borrowRepositoryMock = new Mock<IBorrowRepository>();
            borrowRepositoryMock.Setup(m => m.Add(It.IsAny<BorrowEntity>())).Returns(dbResponse);
            var dtoMapperMock = new Mock<IDtoMapper>();
            dtoMapperMock.Setup(m => m.Map(It.IsAny<BorrowDto>())).Returns(new BorrowEntity());
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(m => m.SetAsBorrowed(It.IsAny<Guid>())).Returns(true);
            var borrowManager = new BorrowManager(borrowRepositoryMock.Object, dtoMapperMock.Object, bookRepositoryMock.Object);

            var result = borrowManager.Add(new BorrowDto());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }

        [Theory]
        [InlineData(true, SUCCEED_REMOVE_MESSAGE)]
        [InlineData(false, FAILED_MESSAGE)]
        public void Remove_ForReponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool dbResponse, string message)
        {
            var borrowRepositoryMock = new Mock<IBorrowRepository>();
            borrowRepositoryMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(dbResponse);
            var dtoMapperMock = new Mock<IDtoMapper>();
            var bookRepositoryMock = new Mock<IBookRepository>();
            //bookRepositoryMock.Setup(m => m.SetAsUnborrowed(It.IsAny<Guid>())).Returns(true);
            var borrowManager = new BorrowManager(borrowRepositoryMock.Object, dtoMapperMock.Object, bookRepositoryMock.Object);

            var result = borrowManager.Remove(Guid.NewGuid());

            result.Succeed.Should().Be(dbResponse);
            result.Message.Should().Be(message);
        }

        [Theory]
        [InlineData(true, true, SUCCED_RETURNED_MESSAGE)]
        [InlineData(false, false, FAILED_MESSAGE)]
        [InlineData(true, false, FAILED_MESSAGE)]
        [InlineData(false, true, FAILED_MESSAGE)]
        public void SetAsReturned_ForResponseFromDatabase_ShouldReturnResponseObjectWithCorrectMessage(bool borrowResponse, bool bookResponse, string message)
        {
            var borrowRepositoryMock = new Mock<IBorrowRepository>();
            borrowRepositoryMock.Setup(m => m.SetAsUnactive(It.IsAny<Guid>())).Returns(borrowResponse);
            var dtoMapperMock = new Mock<IDtoMapper>();
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(m => m.SetAsUnborrowed(It.IsAny<Guid>())).Returns(bookResponse);
            var borrowManager = new BorrowManager(borrowRepositoryMock.Object, dtoMapperMock.Object, bookRepositoryMock.Object);

            var result = borrowManager.SetAsReturned(new ReturnDto() { BorrowId = Guid.NewGuid(), BookId = Guid.NewGuid()});

            result.Succeed.Should().Be(borrowResponse && bookResponse);
            result.Message.Should().Be(message);
        }

    }
}
