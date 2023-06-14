namespace BooksLife.Core
{
    public class BorrowManager : IBorrowManager
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new borrow has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Borrow has been removed.";
        private const string SUCCED_RETURNED_MESSAGE = "Marked borrow as returned.";

        public BorrowManager(IBorrowRepository borrowRepository, IBookRepository bookRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
        }

        public Response Add(BorrowDto borrowDto)
        {
            borrowDto.BorrowDate = DateTime.Now;
            var borrowEntity = borrowDto.ToEntity();
            if (_borrowRepository.Add(borrowEntity))
            {
                if (_bookRepository.SetAsBorrowed(borrowDto.BookId))
                {
                    return new Response()
                    {
                        Succeed = true,
                        Message = SUCCEED_ADD_MESSAGE
                    };
                }
            }
            return new Response()
            {
                Succeed = false,
                Message = FAILED_MESSAGE
            };
        }

        public Response SetAsReturned(BorrowDto borrowDto)
        {
            if (!_borrowRepository.SetAsUnactive(borrowDto.Id))
            {
                return new Response()
                {
                    Succeed = false,
                    Message = FAILED_MESSAGE
                };
            } 
            
            if(!_bookRepository.SetAsUnborrowed(borrowDto.BookId))
            {
                _ = _borrowRepository.SetAsActive(borrowDto.Id);
                return new Response()
                {
                    Succeed = false,
                    Message = FAILED_MESSAGE
                };
            }

            return new Response()
            {
                Succeed = true,
                Message = SUCCED_RETURNED_MESSAGE
            };
        }

        public BorrowDto Get(Guid id)
        {
            return _borrowRepository.Get(id).ToDto();
        }

        public List<BorrowDto> GetAll()
        {
            return _borrowRepository.GetAll().Reverse().ToDto();
        }

        public Response Remove(Guid id)
        {
            if (_borrowRepository.Remove(id))
            {
                //set book as unborrowed
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
    }
}
