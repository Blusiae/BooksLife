namespace BooksLife.Core
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IDtoMapper _dtoMapper;

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
                    Message = "A new author has been added."
                };
            }

            return new Response()
            {
                Succeed = false,
                Message = "Something went wrong!"
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
                    Message = "Author has been removed."
                };
            }

            return new Response()
            {
                Succeed = false,
                Message = "Something went wrong!"
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
