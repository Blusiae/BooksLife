using AutoMapper;

namespace BooksLife.Core
{
    public class BorrowManager : IBorrowManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookManager _bookManager;
        private readonly IMapper _mapper;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new borrow has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Borrow has been removed.";
        private const string SUCCED_RETURNED_MESSAGE = "Marked borrow as returned.";

        public BorrowManager(IUnitOfWork unitOfWork, IBookManager bookManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookManager = bookManager;
            _mapper = mapper;
        }

        public Response Add(AddBorrowDto borrowDto)
        {
            borrowDto.BorrowDate = DateTime.Now;
            var borrowEntity = _mapper.Map<BorrowEntity>(borrowDto);
            if (_unitOfWork.BorrowRepository.Create(borrowEntity))
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
            var borrowEntity = _unitOfWork.BorrowRepository.GetById(returnDto.BorrowId);

            borrowEntity.IsActive = false;

            if (!_unitOfWork.Commit())
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
                _unitOfWork.Commit();
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
            var borrow = _unitOfWork.BorrowRepository.GetById(id, b => b.Book, b => b.Book.BookTitle, b => b.Reader);
            return _mapper.Map<BorrowDto>(borrow);
        }

        public List<BorrowDto> GetPage(int pageSize, int pageNumber, out int totalCount)
        {

            totalCount = _unitOfWork.BorrowRepository.Count();

            var borrows = _unitOfWork.BorrowRepository.GetPage(pageSize, (pageNumber - 1) * pageSize, b => b.Book, b => b.Book.BookTitle, b => b.Reader);

            return _mapper.Map<List<BorrowDto>>(borrows);
        }

        public Response Remove(Guid id)
        {
            var borrow = _unitOfWork.BorrowRepository
                .GetById(id);

            if(borrow != null) 
            {
                var bookId = borrow.BookId;
                var borrowActivity = borrow.IsActive;

                if (_unitOfWork.BorrowRepository.Delete(borrow))
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
