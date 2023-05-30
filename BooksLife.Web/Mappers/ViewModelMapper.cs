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
                    //.AddTransform<string>(x => string.IsNullOrEmpty(x) ? "-" : x)
                    .ForMember("EmailAddress", opt => opt.AddTransform(x => string.IsNullOrEmpty(x.ToString()) ? "-" : x))
                    .ForMember("PhoneNumber", opt => opt.AddTransform(x => string.IsNullOrEmpty(x.ToString()) ? "-" : x));
                config.CreateMap<AddressViewModel, AddressDto>().ReverseMap();
            }).CreateMapper();
        }

        public AuthorViewModel Map(AuthorDto author) => _mapper.Map<AuthorViewModel>(author); //AuthorDto -> AuthorViewModel
        public IEnumerable<AuthorViewModel> Map(IEnumerable<AuthorDto> authors) => _mapper.Map<IEnumerable<AuthorViewModel>>(authors); //Collection of AuthorDto -> collection of AuthorViewModel
        public AuthorDto Map(AuthorViewModel author) => _mapper.Map<AuthorDto>(author); //AuthorViewModel -> AuthorDto
        public IEnumerable<AuthorDto> Map(IEnumerable<AuthorViewModel> authors) => _mapper.Map<IEnumerable<AuthorDto>>(authors); //Collection of AuthorViewModel -> collection of AuthorDto
    
        public ReaderViewModel Map(ReaderDto reader) => _mapper.Map<ReaderViewModel>(reader); //ReaderDto -> ReaderViewModel
        public IEnumerable<ReaderViewModel> Map(IEnumerable<ReaderDto> readers) => _mapper.Map<IEnumerable<ReaderViewModel>>(readers); //Collection of ReaderDto -> collection of ReaderViewModel
        public ReaderDto Map(ReaderViewModel reader) => _mapper.Map<ReaderDto>(reader); //ReaderViewModel -> ReaderDto
        public IEnumerable<ReaderDto> Map(IEnumerable<ReaderViewModel> readers) => _mapper.Map<IEnumerable<ReaderDto>>(readers); //Collection of ReaderViewModel -> collection of ReaderDto

        public AddressViewModel Map(AddressDto address) => _mapper.Map<AddressViewModel>(address); //AddressDto -> AddressViewModel
        public AddressDto Map(AddressViewModel address) => _mapper.Map<AddressDto>(address); //AddressViewModel -> AddressDto
    }
}
