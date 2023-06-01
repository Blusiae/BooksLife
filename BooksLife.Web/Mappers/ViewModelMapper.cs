using AutoMapper;
using BooksLife.Core;

namespace BooksLife.Web
{
    public class ViewModelMapper : IViewModelMapper
    {
        private IMapper _mapper;

        public ViewModelMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<AuthorViewModel, AuthorDto>().ReverseMap();
                config.CreateMap<ReaderViewModel, ReaderDto>();
                config.CreateMap<ReaderDto, ReaderViewModel>()
                    .AddTransform<string?>(x => string.IsNullOrEmpty(x) ? "-" : x);
                config.CreateMap<BookViewModel, BookDto>().ReverseMap();
            }).CreateMapper();
        }

        public AuthorViewModel Map(AuthorDto author) => _mapper.Map<AuthorViewModel>(author); //AuthorDto -> AuthorViewModel
        public IEnumerable<AuthorViewModel> Map(IEnumerable<AuthorDto> authors) => _mapper.Map<IEnumerable<AuthorViewModel>>(authors); //Collection of AuthorDto -> collection of AuthorViewModel
        public AuthorDto Map(AuthorViewModel author) => _mapper.Map<AuthorDto>(author); //AuthorViewModel -> AuthorDto
        public IEnumerable<AuthorDto> Map(IEnumerable<AuthorViewModel> authors) => _mapper.Map<IEnumerable<AuthorDto>>(authors); //Collection of AuthorViewModel -> collection of AuthorDto
    
        public ReaderViewModel Map(ReaderDto book) => _mapper.Map<ReaderViewModel>(book); //ReaderDto -> ReaderViewModel
        public IEnumerable<ReaderViewModel> Map(IEnumerable<ReaderDto> books) => _mapper.Map<IEnumerable<ReaderViewModel>>(books); //Collection of ReaderDto -> collection of ReaderViewModel
        public ReaderDto Map(ReaderViewModel book) => _mapper.Map<ReaderDto>(book); //ReaderViewModel -> ReaderDto
        public IEnumerable<ReaderDto> Map(IEnumerable<ReaderViewModel> books) => _mapper.Map<IEnumerable<ReaderDto>>(books); //Collection of ReaderViewModel -> collection of ReaderDto

        public BookViewModel Map(BookDto book) => _mapper.Map<BookViewModel>(book); //BookDto -> BookViewModel
        public IEnumerable<BookViewModel> Map(IEnumerable<BookDto> books) => _mapper.Map<IEnumerable<BookViewModel>>(books); //Collection of BookDto -> collection of BookViewModel
        public BookDto Map(BookViewModel book) => _mapper.Map<BookDto>(book); //BookViewModel -> BookDto
        public IEnumerable<BookDto> Map(IEnumerable<BookViewModel> books) => _mapper.Map<IEnumerable<BookDto>>(books); //Collection of BookViewModel -> collection of BookDto
    }
}
