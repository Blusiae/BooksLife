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
            var dbResponse = _authorRepository.Create(authorEntity);
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
            var author = _authorRepository.GetById(id);

            if(author != null)
            {
                var dbResponse = _authorRepository.Delete(author);

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
            return _authorRepository.GetById(id).ToDto();
        }

        public IEnumerable<AuthorDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount)
        {
            var filteringMethod = new Func<AuthorEntity, bool>(a => string.IsNullOrEmpty(filterString)
            || string.Join(' ', a.Firstname, a.Lastname).ToLower().Contains(filterString.ToLower()));

            totalCount = _authorRepository.Count(filteringMethod);

            var authors = _authorRepository.GetFilteredPage(filteringMethod, pageSize, (pageNumber - 1) * pageSize);

            return authors.ToDto();
        }

        public IEnumerable<AuthorDto> GetAll()
        {
            var authors = _authorRepository.GetAll();

            return authors.ToDto();
        }
    }
}
