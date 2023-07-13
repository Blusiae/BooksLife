namespace BooksLife.Core
{
    public class BorrowManager : IBorrowManager
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookManager _bookManager;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new borrow has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Borrow has been removed.";
        private const string SUCCED_RETURNED_MESSAGE = "Marked borrow as returned.";

        public BorrowManager(IBorrowRepository borrowRepository, IBookManager bookManager)
        {
            _borrowRepository = borrowRepository;
            _bookManager = bookManager;
        }

        public Response Add(AddBorrowDto borrowDto)
        {
            borrowDto.BorrowDate = DateTime.Now;
            var borrowEntity = borrowDto.ToEntity();
            if (_borrowRepository.Add(borrowEntity))
            {
                if (_bookManager.ChangeAvailability(borrowDto.BookId))
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

        public Response SetAsReturned(ReturnDto returnDto)
        {
            var borrowEntity = _borrowRepository.Get(returnDto.BorrowId);

            borrowEntity.IsActive = false;

            if (!_borrowRepository.Update(borrowEntity))
            {
                return new Response()
                {
                    Succeed = false,
                    Message = FAILED_MESSAGE
                };
            } 
            
            if(!_bookManager.ChangeAvailability(returnDto.BookId))
            {
                borrowEntity.IsActive = true;
                _borrowRepository.Update(borrowEntity);
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

        public IEnumerable<BorrowDto> GetAll()
        {
            return _borrowRepository.GetAll().Reverse().ToDto();
        }

        public Response Remove(Guid id)
        {
            var borrowActivity = _borrowRepository
                .Get(id)
                .IsActive;

            var bookId = _borrowRepository
                .Get(id)
                .BookId;

            if (_borrowRepository.Remove(id))
            {
                if (borrowActivity)
                {
                    _bookManager.ChangeAvailability(bookId);
                }

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
