namespace BooksLife.Core
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IDtoMapper _dtoMapper;

        private const string FAILED_MESSAGE = "Something went wrong!";
        private const string SUCCEED_ADD_MESSAGE = "A new author has been added.";
        private const string SUCCEED_REMOVE_MESSAGE = "Author has been removed.";

        public AuthorManager(IAuthorRepository authorRepository, IDtoMapper dtoMapper)
        {
            _authorRepository = authorRepository;
            _dtoMapper = dtoMapper;
        }
        public Response Add(AuthorDto author)
        {
            var authorEntity = _dtoMapper.Map(author);
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

        public Response Remove(int id)
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

        public AuthorDto Get(int id)
        {
            return _dtoMapper.Map(_authorRepository.Get(id));
        }

        public List<AuthorDto> GetAll()
        {
            return _dtoMapper.Map(_authorRepository.GetAll()).ToList();
        }
    }
}
