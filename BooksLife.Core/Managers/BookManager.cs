namespace BooksLife.Core
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository _bookRepository;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new book has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Book has been removed.";

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Response Add(AddBookDto bookDto)
        {
            var bookEntity = bookDto.ToEntity();
            var dbResponse = _bookRepository.Create(bookEntity);
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

        public bool ChangeAvailability(Guid id)
        {
            var bookEntity = _bookRepository.GetById(id);

            bookEntity.IsBorrowed = !bookEntity.IsBorrowed;

            return _bookRepository.Save();
        }

        public Response Remove(Guid id)
        {
            var book = _bookRepository.GetById(id);

            if (book != null)
            {
                var dbResponse = _bookRepository.Delete(book);

                if (dbResponse)
                {
                    return new Response()
                    {
                        Succeed = true,
                        Message = SUCCEED_REMOVE_MESSAGE
                    };
                }
            }

            return new Response()
            {
                Succeed = false,
                Message = FAILED_MESSAGE
            };
        }

        public IEnumerable<BookDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount)
        {
            var filteringMethod = new Func<BookEntity, bool>(b => string.IsNullOrEmpty(filterString)
            || b.BookTitle.Title.ToLower().Contains(filterString.ToLower()));

            totalCount = _bookRepository.Count(filteringMethod);

            var books = _bookRepository.GetFilteredPage(filteringMethod, pageSize, (pageNumber - 1) * pageSize);

            return books.ToDto();
        }

        public IEnumerable<BookDto> GetAllUnborrowed()
        {
            return _bookRepository
                .FindAll(b => !b.IsBorrowed)
                .OrderBy(b => b.BookTitle.Title)
                .ToDto();
        }

        public BookDto Get(Guid id)
        {
            return _bookRepository.GetById(id).ToDto();
        }
    }
}
