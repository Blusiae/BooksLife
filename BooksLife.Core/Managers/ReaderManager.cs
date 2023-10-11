namespace BooksLife.Core
{
    public class ReaderManager : IReaderManager
    {
        private readonly IUnitOfWork _unitOfWork;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new reader has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Reader has been removed.";

        public ReaderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response Add(AddReaderDto readerDto)
        {
            var readerEntity = readerDto.ToEntity();
            var dbResponse = _unitOfWork.ReaderRepository.Create(readerEntity);
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
            var reader = _unitOfWork.ReaderRepository.GetById(id);

            if (reader != null)
            {
                var dbResponse = _unitOfWork.ReaderRepository.Delete(reader);

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

        public ReaderDto Get(Guid id)
        {
            return _unitOfWork.ReaderRepository.GetById(id).ToDto();
        }

        public IEnumerable<ReaderDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount)
        {
            var filteringMethod = new Func<ReaderEntity, bool>(r => string.IsNullOrEmpty(filterString)
            || string.Join(' ', r.Firstname, r.Lastname).ToLower().Contains(filterString.ToLower()));

            totalCount = _unitOfWork.ReaderRepository.Count(filteringMethod);

            var books = _unitOfWork.ReaderRepository.GetFilteredPage(filteringMethod, pageSize, (pageNumber - 1) * pageSize);

            return books.ToDto();
        }

        public IEnumerable<ReaderDto> GetAll()
        {
            return _unitOfWork.ReaderRepository
                .GetAll()
                .OrderBy(x => x.Firstname)
                .ToDto();
        }
        
    }
}
