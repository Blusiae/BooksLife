using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace BookTitlesLife.Tests 
{ 
    public class BookTitleTitleControllerTests
    {
        [Fact]
        public void List_WhenCalled_ShouldReturnListViewWithListOfBooksAsViewModel()
        {
            var bookTitleManagerMock = new Mock<IBookTitleManager>();
            bookTitleManagerMock.Setup(m => m.GetAll()).Returns(new List<BookTitleDto>());
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            viewModelMapperMock.Setup(m => m.Map(It.IsAny<List<BookTitleDto>>())).Returns(new List<BookTitleViewModel>());
            var authorManagerMock = new Mock<IAuthorManager>();
            var bookTitleController = new BookTitleController(bookTitleManagerMock.Object, viewModelMapperMock.Object, authorManagerMock.Object);

            var result = bookTitleController.List() as ViewResult;

            result.Model.Should().BeOfType<List<BookTitleViewModel>>();
            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "A new book title has been added.")]
        [InlineData(false, "Something went wrong!")]
        public void Add_ForCorrectViewModel_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var bookTitleManagerMock = new Mock<IBookTitleManager>();
            bookTitleManagerMock.Setup(m => m.Add(It.IsAny<BookTitleDto>())).Returns(response);
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            viewModelMapperMock.Setup(m => m.Map(It.IsAny<BookTitleViewModel>())).Returns(new BookTitleDto());
            var authorManagerMock = new Mock<IAuthorManager>();
            var bookTitleController = new BookTitleController(bookTitleManagerMock.Object, viewModelMapperMock.Object, authorManagerMock.Object);
            var bookTitle = new BookTitleViewModel()
            {
                Title = "Title1",
                PublicationYear = 2000,
                AuthorId = Guid.NewGuid()
            };

            var result = bookTitleController.Add(bookTitle) as RedirectToActionResult;

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
            var bookTitleManagerMock = new Mock<IBookTitleManager>();
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            var authorManagerMock = new Mock<IAuthorManager>();
            authorManagerMock.Setup(m => m.GetAll()).Returns(new List<AuthorDto>());
            var bookTitleController = new BookTitleController(bookTitleManagerMock.Object, viewModelMapperMock.Object, authorManagerMock.Object);

            var result = bookTitleController.Add() as ViewResult;

            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "Book title has been removed.")]
        [InlineData(false, "Something went wrong!")]
        public void Remove_ForId_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var bookTitleManagerMock = new Mock<IBookTitleManager>();
            bookTitleManagerMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(response);
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            var authorManagerMock = new Mock<IAuthorManager>();
            var bookTitleController = new BookTitleController(bookTitleManagerMock.Object, viewModelMapperMock.Object, authorManagerMock.Object);

            var result = bookTitleController.Remove(Guid.NewGuid()) as RedirectToActionResult;

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
