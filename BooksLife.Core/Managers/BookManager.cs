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

        public bool ChangeAvailability(Guid id)
        {
            var bookEntity = _bookRepository.Get(id);

            bookEntity.IsBorrowed = !bookEntity.IsBorrowed;

            return _bookRepository.Update(bookEntity);
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

        public IEnumerable<BookDto> GetAll(int pageSize, int pageNumber, out int totalCount)
        {
            totalCount = _bookRepository.Count();
            return _bookRepository.GetAll(pageSize, pageSize * (pageNumber-1)).ToDto();
        }

        public BookDto Get(Guid id)
        {
            return _bookRepository.Get(id).ToDto();
        }
    }
}
