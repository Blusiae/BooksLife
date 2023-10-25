using AutoMapper;

namespace BooksLife.Core
{
    public class BookManager : IBookManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new book has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Book has been removed.";

        public BookManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response Add(AddBookDto bookDto)
        {
            var bookEntity = _mapper.Map<BookEntity>(bookDto);
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

        public List<BookDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount)
        {
            var filteringMethod = new Func<BookEntity, bool>(b => string.IsNullOrEmpty(filterString)
            || b.BookTitle.Title.ToLower().Contains(filterString.ToLower()));

            totalCount = _unitOfWork.BookRepository.Count(filteringMethod);

            var books = _unitOfWork.BookRepository.GetFilteredPage(filteringMethod, pageSize, (pageNumber - 1) * pageSize, b => b.BookTitle, b => b.BookTitle.Author);

            return _mapper.Map<List<BookDto>>(books);
        }

        public List<BookDto> GetAllUnborrowed()
        {
            var books = _unitOfWork.BookRepository
                .FindAll(b => !b.IsBorrowed, b => b.BookTitle, b => b.BookTitle.Author)
                .OrderBy(b => b.BookTitle.Title);

            return _mapper.Map<List<BookDto>>(books);
        }

        public BookDto Get(Guid id)
        {
            var book = _unitOfWork.BookRepository.GetById(id, b => b.BookTitle, b => b.BookTitle.Author);
            return _mapper.Map<BookDto>(book);
        }
    }
}
