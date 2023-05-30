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
            readerManagerMock.Setup(m => m.GetAllForList()).Returns(new List<ReaderDto>());
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            viewModelMapperMock.Setup(m => m.Map(It.IsAny<List<ReaderDto>>())).Returns(new List<ReaderViewModel>());
            var readerController = new ReaderController(readerManagerMock.Object, viewModelMapperMock.Object);

            var result = readerController.List() as ViewResult;

            result.Model.Should().BeOfType<List<AuthorViewModel>>();
            result.ViewName.Should().BeNull();
        }

        [Fact]
        public void Index_ForCorrectId_ShouldReturnIndexViewWithReaderAsViewModel()
        {
            var readerManagerMock = new Mock<IReaderManager>();
            readerManagerMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(new ReaderDto());
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            viewModelMapperMock.Setup(m => m.Map(It.IsAny<ReaderDto>())).Returns(new ReaderViewModel());
            var readerController = new ReaderController(readerManagerMock.Object, viewModelMapperMock.Object);

            var result = readerController.Index(new Guid()) as ViewResult;

            result.Model.Should().BeOfType<List<AuthorViewModel>>();
            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "A new reader has been added.")]
        [InlineData(false, "Something went wrong!")]
        public void Add_ForCorrectViewModel_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var readerManagerMock = new Mock<IReaderManager>();
            readerManagerMock.Setup(m => m.Add(It.IsAny<ReaderDto>())).Returns(response);
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            viewModelMapperMock.Setup(m => m.Map(It.IsAny<ReaderViewModel>())).Returns(new ReaderDto());
            var readerController = new ReaderController(readerManagerMock.Object, viewModelMapperMock.Object);
            var reader = new ReaderViewModel()
            {
                Firstname = "Firstname",
                Lastname = "Lastname",
                Address = new AddressViewModel() { Country = "Poland", City = "Warsaw"}
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
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            var readerController = new ReaderController(readerManagerMock.Object, viewModelMapperMock.Object);

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
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            var readerController = new ReaderController(readerManagerMock.Object, viewModelMapperMock.Object);

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
