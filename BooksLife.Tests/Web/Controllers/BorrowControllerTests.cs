using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace BooksLife.Tests
{
    public class BorrowControllerTests
    {
        [Fact]
        public void List_WhenCalled_ShouldReturnListViewWithListOfBorrowsAsViewModel()
        {
            var borrowManagerMock = new Mock<IBorrowManager>();
            borrowManagerMock.Setup(m => m.GetAll()).Returns(new List<BorrowDto>());
            var bookManagerMock = new Mock<IBookManager>();
            var readerManagerMock = new Mock<IReaderManager>();
            var borrowController = new BorrowController(borrowManagerMock.Object, bookManagerMock.Object, readerManagerMock.Object);

            var result = borrowController.List() as ViewResult;

            result.Model.Should().BeOfType<List<BorrowViewModel>>();
            result.ViewName.Should().BeNull();
        }

        [Fact]
        public void Add_ForNoParameters_ShouldReturnAddView()
        {
            var borrowManagerMock = new Mock<IBorrowManager>();
            var bookManagerMock = new Mock<IBookManager>();
            bookManagerMock.Setup(m => m.GetAll()).Returns(new List<BookDto>());
            var readerManagerMock = new Mock<IReaderManager>();
            readerManagerMock.Setup(m => m.GetAllForList()).Returns(new List<ReaderDto>());
            var borrowController = new BorrowController(borrowManagerMock.Object, bookManagerMock.Object, readerManagerMock.Object);

            var result = borrowController.Add() as ViewResult;

            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "A new borrow has been added.")]
        [InlineData(false, "Something went wrong!")]
        public void Add_ForCorrectViewModel_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var borrowManagerMock = new Mock<IBorrowManager>();
            borrowManagerMock.Setup(m => m.Add(It.IsAny<AddBorrowDto>())).Returns(response);
            var bookManagerMock = new Mock<IBookManager>();
            var readerManagerMock = new Mock<IReaderManager>();
            var borrowController = new BorrowController(borrowManagerMock.Object, bookManagerMock.Object, readerManagerMock.Object);
            var borrow = new AddBorrowViewModel()
            {
                BookId = Guid.NewGuid(),
                ReaderId = Guid.NewGuid(),
                BorrowDate = new DateTime(),
                ReturnDate = new DateTime()
            };

            var result = borrowController.Add(borrow) as RedirectToActionResult;

            var expectedRouteValues = new RouteValueDictionary()
            {
                { "Succeed", succeed },
                { "Message", message },
            };

            result.ActionName.Should().Be("List");
            result.RouteValues.Should().BeEquivalentTo(expectedRouteValues);
        }

        [Theory]
        [InlineData(true, "Borrow has been removed.")]
        [InlineData(false, "Something went wrong!")]
        public void Remove_ForId_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var borrowManagerMock = new Mock<IBorrowManager>();
            borrowManagerMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(response);
            var bookManagerMock = new Mock<IBookManager>();
            var readerManagerMock = new Mock<IReaderManager>();
            var borrowController = new BorrowController(borrowManagerMock.Object, bookManagerMock.Object, readerManagerMock.Object);

            var result = borrowController.Remove(Guid.NewGuid()) as RedirectToActionResult;

            var expectedRouteValues = new RouteValueDictionary()
            {
                { "Succeed", succeed },
                { "Message", message },
            };

            result.ActionName.Should().Be("List");
            result.RouteValues.Should().BeEquivalentTo(expectedRouteValues);
        }
        
        [Theory]
        [InlineData(true, "Marked borrow as returned.")]
        [InlineData(false, "Something went wrong!")]
        public void SetAsReturned_ForId_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var borrowManagerMock = new Mock<IBorrowManager>();
            borrowManagerMock.Setup(m => m.SetAsReturned(It.IsAny<ReturnDto>())).Returns(response);
            borrowManagerMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(new BorrowDto());
            var bookManagerMock = new Mock<IBookManager>();
            var readerManagerMock = new Mock<IReaderManager>();
            var borrowController = new BorrowController(borrowManagerMock.Object, bookManagerMock.Object, readerManagerMock.Object);

            var result = borrowController.SetAsReturned(Guid.NewGuid()) as RedirectToActionResult;

            var expectedRouteValues = new RouteValueDictionary()
            {
                { "Succeed", succeed },
                { "Message", message },
            };

            result.ActionName.Should().Be("List");
            result.RouteValues.Should().BeEquivalentTo(expectedRouteValues);
        }
    }
}
