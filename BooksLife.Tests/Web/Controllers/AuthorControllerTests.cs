﻿using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
            var authorController = new AuthorController(authorManagerMock.Object);

            var result = authorController.List() as ViewResult;

            result.Model.Should().BeOfType<List<AuthorViewModel>>();
            result.ViewName.Should().BeNull();
        }

        [Fact]
        public void Add_ForNoParameters_ShouldReturnAddView()
        {
            var authorManagerMock = new Mock<IAuthorManager>();
            var authorController = new AuthorController(authorManagerMock.Object);

            var result = authorController.Add() as ViewResult;

            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "A new author has been added.")]
        [InlineData(false, "Something went wrong!")]
        public void Add_ForCorrectViewModel_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var authorManagerMock = new Mock<IAuthorManager>();
            authorManagerMock.Setup(m => m.Add(It.IsAny<AddAuthorDto>())).Returns(response);
            var authorController = new AuthorController(authorManagerMock.Object);
            var author = new AddAuthorViewModel()
            {
                Firstname = "Firstname",
                Lastname = "Lastname"
            };

            var result = authorController.Add(author) as RedirectToActionResult;

            var expectedRouteValues = new RouteValueDictionary()
            {
                { "Succeed", succeed },
                { "Message", message },
            };

            result.ActionName.Should().Be("List");
            result.RouteValues.Should().BeEquivalentTo(expectedRouteValues);
        }

        [Theory]
        [InlineData(true, "Author has been removed.")]
        [InlineData(false, "Something went wrong!")]
        public void Remove_ForId_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var authorManagerMock = new Mock<IAuthorManager>();
            authorManagerMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(response);
            var authorController = new AuthorController(authorManagerMock.Object);

            var result = authorController.Remove(Guid.NewGuid()) as RedirectToActionResult;

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
