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
            if (_borrowRepository.Create(borrowEntity))
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
            var borrowEntity = _borrowRepository.GetById(returnDto.BorrowId);

            borrowEntity.IsActive = false;

            if (!_borrowRepository.Save())
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
                _borrowRepository.Save();
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
            return _borrowRepository.GetById(id).ToDto();
        }

        public IEnumerable<BorrowDto> GetPage(int pageSize, int pageNumber, out int totalCount)
        {

            totalCount = _borrowRepository.Count();

            var borrows = _borrowRepository.GetPage(pageSize, (pageNumber - 1) * pageSize);

            return borrows.ToDto();
        }

        public Response Remove(Guid id)
        {
            var borrow = _borrowRepository
                .GetById(id);

            if(borrow != null) 
            {
                var bookId = borrow.BookId;
                var borrowActivity = borrow.IsActive;

                if (_borrowRepository.Delete(borrow))
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
            }

            return new Response()
            {
                Succeed = false,
                Message = FAILED_MESSAGE
            };
        }
    }
}
