namespace BooksLife.Core
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorRepository _authorRepository;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new author has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Author has been removed.";

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public Response Add(AddAuthorDto author)
        {
            var authorEntity = author.ToEntity();
            var dbResponse = _authorRepository.Add(authorEntity);
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
            var dbResponse = _authorRepository.Remove(id);
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

        public AuthorDto Get(Guid id)
        {
            return _authorRepository.Get(id).ToDto();
        }

        public IEnumerable<AuthorDto> GetAll(int pageSize, int pageNumber, out int totalCount)
        {
            totalCount = _authorRepository.Count();
            return _authorRepository.GetAll(pageSize, pageSize * (pageNumber-1)).ToDto();
        }
    }
}
