namespace BooksLife.Core
{
    public class BookManager : IBookManager
    {
        private readonly IUnitOfWork _unitOfWork;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new book has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Book has been removed.";

        public BookManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response Add(AddBookDto bookDto)
        {
            var bookEntity = bookDto.ToEntity();
            var dbResponse = _unitOfWork.BookRepository.Create(bookEntity);
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
            var bookEntity = _unitOfWork.BookRepository.GetById(id);

            bookEntity.IsBorrowed = !bookEntity.IsBorrowed;

            return _unitOfWork.Commit();
        }

        public Response Remove(Guid id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);

            if (book != null)
            {
                var dbResponse = _unitOfWork.BookRepository.Delete(book);

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

            totalCount = _unitOfWork.BookRepository.Count(filteringMethod);

            var books = _unitOfWork.BookRepository.GetFilteredPage(filteringMethod, pageSize, (pageNumber - 1) * pageSize);

            return books.ToDto();
        }

        public IEnumerable<BookDto> GetAllUnborrowed()
        {
            return _unitOfWork.BookRepository
                .FindAll(b => !b.IsBorrowed)
                .OrderBy(b => b.BookTitle.Title)
                .ToDto();
        }

        public BookDto Get(Guid id)
        {
            return _unitOfWork.BookRepository.GetById(id).ToDto();
        }
    }
}
