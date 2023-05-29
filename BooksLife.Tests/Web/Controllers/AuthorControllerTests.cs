using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BooksLife.Tests
{
    public class AuthorControllerTests
    {
        [Fact]
        public void List_WhenCalled_ShouldReturnListViewWithListOfAuthorsAsViewModel()
        {
            var authorManagerMock = new Mock<IAuthorManager>();
            authorManagerMock.Setup(m => m.GetAll()).Returns(new List<AuthorDto>());
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            viewModelMapperMock.Setup(m => m.Map(It.IsAny<List<AuthorDto>>())).Returns(new List<AuthorViewModel>());
            var authorController = new AuthorController(authorManagerMock.Object, viewModelMapperMock.Object);

            var result = authorController.List() as ViewResult;

            result.Model.Should().BeOfType<List<AuthorViewModel>>();
            result.ViewName.Should().BeNull();
        }

        [Fact]
        public void Add_ForNoParameters_ShouldReturnAddView()
        {
            var authorManagerMock = new Mock<IAuthorManager>();
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            var authorController = new AuthorController(authorManagerMock.Object, viewModelMapperMock.Object);

            var result = authorController.Add() as ViewResult;

            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "A new author has been added.")]
        [InlineData(false, "Something went wrong!")]
        public void Add_ForCorrectViewModel_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Core.Response() { Succeed = succeed, Message = message };
            var authorManagerMock = new Mock<IAuthorManager>();
            authorManagerMock.Setup(m => m.Add(It.IsAny<AuthorDto>())).Returns(response);
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            viewModelMapperMock.Setup(m => m.Map(It.IsAny<AuthorViewModel>())).Returns(new AuthorDto());
            var authorController = new AuthorController(authorManagerMock.Object, viewModelMapperMock.Object);
            var author = new AuthorViewModel()
            {
                Firstname = "Firstname",
                Lastname = "Lastname"
            };

            var result = authorController.Add(author) as RedirectToActionResult;

            result.ActionName.Should().Be("List");
            result.RouteValues.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void Add_ForIncorrectViewModel_ShouldReturnAddViewWithIncorrectViewModelAsModel()
        {
            var authorManagerMock = new Mock<IAuthorManager>();
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            var authorController = new AuthorController(authorManagerMock.Object, viewModelMapperMock.Object);
            var author = new AuthorViewModel()
            {
                Firstname = "Firstname"
            };

            var result = authorController.Add(author) as ViewResult;

            result.ViewName.Should().BeNull();
            result.Model.Should().BeEquivalentTo(author);
        }

        [Theory]
        [InlineData(true, "Author has been removed.")]
        [InlineData(false, "Something went wrong!")]
        public void Remove_ForId_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Core.Response() { Succeed = succeed, Message = message };
            var authorManagerMock = new Mock<IAuthorManager>();
            authorManagerMock.Setup(m => m.Remove(It.IsAny<int>())).Returns(response);
            var viewModelMapperMock = new Mock<IViewModelMapper>();
            var authorController = new AuthorController(authorManagerMock.Object, viewModelMapperMock.Object);

            var result = authorController.Remove(0) as RedirectToActionResult;

            result.ActionName.Should().Be("List");
            result.RouteValues.Should().BeEquivalentTo(response);
        }
    }
}
