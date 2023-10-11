namespace BooksLife.Core
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IUnitOfWork _unitOfWork;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new author has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Author has been removed.";

        public AuthorManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Response Add(AddAuthorDto author)
        {
            var authorEntity = author.ToEntity();
            var dbResponse = _unitOfWork.AuthorRepository.Create(authorEntity);
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
            var author = _unitOfWork.AuthorRepository.GetById(id);

            if(author != null)
            {
                var dbResponse = _unitOfWork.AuthorRepository.Delete(author);

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

        public AuthorDto Get(Guid id)
        {
            return _unitOfWork.AuthorRepository.GetById(id).ToDto();
        }

        public IEnumerable<AuthorDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount)
        {
            var filteringMethod = new Func<AuthorEntity, bool>(a => string.IsNullOrEmpty(filterString)
            || string.Join(' ', a.Firstname, a.Lastname).ToLower().Contains(filterString.ToLower()));

            totalCount = _unitOfWork.AuthorRepository.Count(filteringMethod);

            var authors = _unitOfWork.AuthorRepository.GetFilteredPage(filteringMethod, pageSize, (pageNumber - 1) * pageSize);

            return authors.ToDto();
        }

        public IEnumerable<AuthorDto> GetAll()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll();

            return authors.ToDto();
        }
    }
}
