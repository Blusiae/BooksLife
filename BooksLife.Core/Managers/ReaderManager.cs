namespace BooksLife.Core
{
    public class ReaderManager : IReaderManager
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IDtoMapper _dtoMapper;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new reader has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Reader has been removed.";

        public ReaderManager(IReaderRepository readerRepository, IDtoMapper dtoMapper)
        {
            _readerRepository = readerRepository;
            _dtoMapper = dtoMapper;
        }

        public Response Add(ReaderDto readerDto)
        {
            var readerEntity = _dtoMapper.Map(readerDto);
            var dbResponse = _readerRepository.Add(readerEntity);
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
            var dbResponse = _readerRepository.Remove(id);
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

        public ReaderDto Get(Guid id)
        {
            return _dtoMapper.Map(_readerRepository.Get(id));
        }

        public List<ReaderDto> GetAllForList()
        {
            var readerEntities = _readerRepository.GetAll().Select(x => new ReaderEntity()
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                EmailAddress = x.EmailAddress,
                PhoneNumber = x.PhoneNumber
            });

            return _dtoMapper.Map(readerEntities).ToList();
        }
        
    }
}
