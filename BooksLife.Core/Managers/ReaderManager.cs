namespace BooksLife.Core
{
    public class ReaderManager : IReaderManager
    {
        private readonly IReaderRepository _readerRepository;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new reader has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Reader has been removed.";

        public ReaderManager(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public Response Add(AddReaderDto readerDto)
        {
            var readerEntity = readerDto.ToEntity();
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
            return _readerRepository.Get(id).ToDto();
        }

        public IEnumerable<ReaderDto> GetAll(int pageSize, int pageNumber, string? filterString, out int totalCount)
        {
            return _readerRepository.GetAll(out totalCount, pageSize, pageSize * (pageNumber-1), filterString).ToDto();
        }

        public IEnumerable<ReaderDto> GetAll()
        {
            var totalCount = _readerRepository.Count();
            return _readerRepository
                .GetAll(totalCount)
                .OrderBy(x => x.Firstname)
                .ToDto();
        }
        
    }
}
