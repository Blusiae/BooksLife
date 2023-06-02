namespace BooksLife.Core
{
    public class BorrowManager : IBorrowManager
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IDtoMapper _mapper;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new borrow has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Borrow has been removed.";

        public BorrowManager(IBorrowRepository borrowRepository, IDtoMapper mapper)
        {
            _borrowRepository = borrowRepository;
            _mapper = mapper;
        }

        public Response Add(BorrowDto borrowDto)
        {
            borrowDto.BorrowDate = DateTime.Now;
            var borrowEntity = _mapper.Map(borrowDto);
            if (_borrowRepository.Add(borrowEntity))
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

        public BorrowDto Get(Guid id)
        {
            return _mapper.Map(_borrowRepository.Get(id));
        }

        public List<BorrowDto> GetAll()
        {
            return _mapper.Map(_borrowRepository.GetAll()).ToList();
        }

        public Response Remove(Guid id)
        {
            if (_borrowRepository.Remove(id))
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
    }
}
