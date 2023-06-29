﻿namespace BooksLife.Core
{
    public class BookTitleManager : IBookTitleManager
    {
        private readonly IBookTitleRepository _bookTitleRepository;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new book title has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Book title has been removed.";

        public BookTitleManager(IBookTitleRepository bookTitleRepository)
        {
            _bookTitleRepository = bookTitleRepository;
        }

        public Response Add(AddBookTitleDto bookTitleDto)
        {
            var bookEntity = bookTitleDto.ToEntity();
            var dbResponse = _bookTitleRepository.Add(bookEntity);
            if (dbResponse)
            {
                return new Response()
                {
                    Succeed = true,
                    Message = SUCCEED_ADD_MESSAGE
                };
            }

            return new Response()
            {
                Succeed = false,
                Message = FAILED_MESSAGE
            };
        }

        public Response Remove(Guid id)
        {
            var dbResponse = _bookTitleRepository.Remove(id);
            if (dbResponse)
            {
                return new Response()
                {
                    Succeed = true,
                    Message = SUCCEED_REMOVE_MESSAGE
                };
            }

            return new Response()
            {
                Succeed = false,
                Message = FAILED_MESSAGE
            };
        }

        public List<BookTitleDto> GetAll()
        {
            return _bookTitleRepository.GetAll().ToDto();
        }
    }
}
