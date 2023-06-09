﻿using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace BooksLife.Tests
{
    public class BookControllerTests
    {
        [Fact]
        public void List_WhenCalled_ShouldReturnListViewWithListOfBooksAsViewModel()
        {
            var bookManagerMock = new Mock<IBookManager>();
            bookManagerMock.Setup(m => m.GetAll()).Returns(new List<BookDto>());
            var authorManagerMock = new Mock<IAuthorManager>();
            var bookController = new BookController(bookManagerMock.Object, authorManagerMock.Object);

            var result = bookController.List() as ViewResult;

            result.Model.Should().BeOfType<List<BookViewModel>>();
            result.ViewName.Should().BeNull();
        }

        [Fact]
        public void Index_ForCorrectId_ShouldReturnIndexViewWithBookAsViewModel()
        {
            var bookManagerMock = new Mock<IBookManager>();
            bookManagerMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(new BookDto());
            var authorManagerMock = new Mock<IAuthorManager>();
            var bookController = new BookController(bookManagerMock.Object, authorManagerMock.Object);

            var result = bookController.Index(new Guid()) as ViewResult;

            result.Model.Should().BeOfType<BookViewModel>();
            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "A new book has been added.")]
        [InlineData(false, "Something went wrong!")]
        public void Add_ForCorrectViewModel_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var bookManagerMock = new Mock<IBookManager>();
            bookManagerMock.Setup(m => m.Add(It.IsAny<AddBookDto>())).Returns(response);
            var authorManagerMock = new Mock<IAuthorManager>();
            var bookController = new BookController(bookManagerMock.Object, authorManagerMock.Object);
            var book = new AddBookViewModel()
            {
                Title = "Title",
                PublicationYear = 1999,
                AuthorId = Guid.NewGuid(),
                EditionPublicationYear = 2000,
                Condition = BookCondition.Good,
                ConditionNote = "Everything's good."
            };

            var result = bookController.Add(book) as RedirectToActionResult;

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
            var bookManagerMock = new Mock<IBookManager>();
            var authorManagerMock = new Mock<IAuthorManager>();
            authorManagerMock.Setup(m => m.GetAll()).Returns(new List<AuthorDto>());
            var bookController = new BookController(bookManagerMock.Object, authorManagerMock.Object);

            var result = bookController.Add() as ViewResult;

            result.ViewName.Should().BeNull();
        }

        [Theory]
        [InlineData(true, "Book has been removed.")]
        [InlineData(false, "Something went wrong!")]
        public void Remove_ForId_ShouldCallManagerAndRedirectToListAndPassTheResponse(bool succeed, string message)
        {
            var response = new Response() { Succeed = succeed, Message = message };
            var bookManagerMock = new Mock<IBookManager>();
            bookManagerMock.Setup(m => m.Remove(It.IsAny<Guid>())).Returns(response);
            var authorManagerMock = new Mock<IAuthorManager>();
            var bookController = new BookController(bookManagerMock.Object, authorManagerMock.Object);

            var result = bookController.Remove(Guid.NewGuid()) as RedirectToActionResult;

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
