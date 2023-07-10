using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace BooksLife.Tests
{
    public class ReaderControllerTests
    {
        [Fact]
        public void List_WhenCalled_ShouldReturnListViewWithListOfReadersAsViewModel()
        {
            var readerManagerMock = new Mock<IReaderManager>();
            readerManagerMock.Setup(m => m.GetAll()).Returns(new List<ReaderDto>());
            var readerController = new ReaderController(readerManagerMock.Object);

            var result = readerController.List() as ViewResult;

            result.Model.Should().BeOfType<List<ReaderViewModel>>();
            result.ViewName.Should().BeNull();
        }

        [Fact]
        public void Index_ForCorrectId_ShouldReturnIndexViewWithReaderAsViewModel()
        {
            var readerManagerMock = new Mock<IReaderManager>();
            readerManagerMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(new ReaderDto());
            var readerController = new ReaderController(readerManagerMock.Object);

            var result = readerController.Index(new Guid()) as ViewResult;

            result.Model.Should().BeOfType<ReaderViewModel>();
            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "A new reader has been added.")]
        [InlineData(false, "Something went wrong!")]
        public void Add_ForCorrectViewModel_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var readerManagerMock = new Mock<IReaderManager>();
            readerManagerMock.Setup(m => m.Add(It.IsAny<AddReaderDto>())).Returns(response);
            var readerController = new ReaderController(readerManagerMock.Object);
            var reader = new AddReaderViewModel()
            {
                Firstname = "Firstname",
                Lastname = "Lastname",
                Country = "Poland",
                City = "Warsaw",
                Street = "Street",
                Birthdate = new DateTime()
            };

            var result = readerController.Add(reader) as RedirectToActionResult;

            var expectedRouteValues = new RouteValueDictionary()
            {
                { "Succeed", succeed },
                { "Message", message },
            };

            result.ActionName.Should().Be("List");
            result.RouteValues.Should().BeEquivalentTo(expectedRouteValues);
        }

        [Fact]
        public void Add_ForNoParameters_ShouldReturnAddView()
        {
            var readerManagerMock = new Mock<IReaderManager>();
            var readerController = new ReaderController(readerManagerMock.Object);

            var result = readerController.Add() as ViewResult;

            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "Reader has been removed.")]
        [InlineData(false, "Something went wrong!")]
        public void Remove_ForId_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var readerManagerMock = new Mock<IReaderManager>();
            readerManagerMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(response);
            var readerController = new ReaderController(readerManagerMock.Object);

            var result = readerController.Remove(Guid.NewGuid()) as RedirectToActionResult;

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
