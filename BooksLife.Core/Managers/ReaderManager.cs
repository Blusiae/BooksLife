using AutoMapper;

namespace BooksLife.Core
{
    public class ReaderManager : IReaderManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new reader has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Reader has been removed.";

        public ReaderManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response Add(AddReaderDto readerDto)
        {
            var readerEntity = _mapper.Map<ReaderEntity>(readerDto);
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
            var reader = _unitOfWork.ReaderRepository.GetById(id, r => r.Address);
            return _mapper.Map<ReaderDto>(reader);
        }

        public List<ReaderDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount)
        {
            var filteringMethod = new Func<ReaderEntity, bool>(r => string.IsNullOrEmpty(filterString)
            || string.Join(' ', r.Firstname, r.Lastname).ToLower().Contains(filterString.ToLower()));

            totalCount = _unitOfWork.ReaderRepository.Count(filteringMethod);

            var readers = _unitOfWork.ReaderRepository.GetFilteredPage(filteringMethod, pageSize, (pageNumber - 1) * pageSize);

            return _mapper.Map<List<ReaderDto>>(readers);
        }

        public List<ReaderDto> GetAll()
        {
            var readers = _unitOfWork.ReaderRepository
                .GetAll()
                .OrderBy(x => x.Firstname);

            return _mapper.Map<List<ReaderDto>>(readers);
        }
        
    }
}
