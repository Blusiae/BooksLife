using AutoMapper;
using BooksLife.Core;

namespace BooksLife.Web
{
    public class ViewModelMapper
    {
        private IMapper _mapper;

        public ViewModelMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<AuthorViewModel, AuthorDto>().ReverseMap();
            }).CreateMapper();
        }

        public AuthorViewModel Map(AuthorDto author) => _mapper.Map<AuthorViewModel>(author); //AuthorDto -> AuthorViewModel
        public IEnumerable<AuthorViewModel> Map(IEnumerable<AuthorDto> authors) => _mapper.Map<IEnumerable<AuthorViewModel>>(authors); //Collection of AuthorDto -> collection of AuthorViewModel
        public AuthorDto Map(AuthorViewModel author) => _mapper.Map<AuthorDto>(author); //AuthorViewModel -> AuthorDto
        public IEnumerable<AuthorDto> Map(IEnumerable<AuthorViewModel> authors) => _mapper.Map<IEnumerable<AuthorDto>>(authors); //Collection of AuthorViewModel -> collection of AuthorDto
    }
}
