namespace BooksLife.Core
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository _bookRepository;
        private readonly IDtoMapper _dtoMapper;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new book has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Book has been removed.";

        public BookManager(IBookRepository bookRepository, IDtoMapper dtoMapper)
        {
            _bookRepository = bookRepository;
            _dtoMapper = dtoMapper;
        }

        public Response Add(BookDto bookDto)
        {
            var bookEntity = _dtoMapper.Map(bookDto);
            var dbResponse = _bookRepository.Add(bookEntity);
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
            var dbResponse = _bookRepository.Remove(id);
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

        public List<BookDto> GetAll()
        {
            return _dtoMapper.Map(_bookRepository.GetAll()).ToList();
        }

        public BookDto Get(Guid id)
        {
            return _dtoMapper.Map(_bookRepository.Get(id));
        }
    }
}
