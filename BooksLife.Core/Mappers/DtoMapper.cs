using AutoMapper;

namespace BooksLife.Core
{
    public class DtoMapper : IDtoMapper
    {
        private IMapper _mapper;

        public DtoMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<AuthorEntity, AuthorDto>().ReverseMap();
                config.CreateMap<ReaderEntity, ReaderDto>()
                    .ForMember(x => x.Country, y => y.MapFrom(z => z.Address.Country))
                    .ForMember(x => x.City, y => y.MapFrom(z => z.Address.City))
                    .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.Address.PostalCode))
                    .ForMember(x => x.Street, y => y.MapFrom(z => z.Address.Street))
                    .ForMember(x => x.HouseNumber, y => y.MapFrom(z => z.Address.HouseNumber))
                    .ForMember(x => x.FlatNumber, y => y.MapFrom(z => z.Address.FlatNumber))
                    .ReverseMap();
                config.CreateMap<BookDto, BookEntity>();
                config.CreateMap<BookEntity, BookDto>()
                    .ForMember(x => x.AuthorName, y => y.MapFrom(z => $"{z.BookTitle.Author.Firstname} {z.BookTitle.Author.Lastname}"))
                    .ForMember(x => x.Title, y => y.MapFrom(z => z.BookTitle.Title))
                    .ForMember(x => x.PublicationYear, y => y.MapFrom(z => z.BookTitle.PublicationYear));
                config.CreateMap<BookTitleDto, BookTitleEntity>();
                config.CreateMap<BookTitleEntity, BookTitleDto>()
                    .ForMember(x => x.AuthorName, y => y.MapFrom(z => $"{z.Author.Firstname} {z.Author.Lastname}"));
            }).CreateMapper();
        }

        public AuthorDto Map(AuthorEntity Author) => _mapper.Map<AuthorDto>(Author); //AuthorEntity -> AuthorDto
        public IEnumerable<AuthorDto> Map(IEnumerable<AuthorEntity> Authors) => _mapper.Map<IEnumerable<AuthorDto>>(Authors); //Collection of AuthorEntity -> collection of AuthorDto

        public AuthorEntity Map(AuthorDto Author) => _mapper.Map<AuthorEntity>(Author); //AuthorDto -> AuthorEntity
        public IEnumerable<AuthorEntity> Map(IEnumerable<AuthorDto> Authors) => _mapper.Map<IEnumerable<AuthorEntity>>(Authors); //Collection of AuthorDto -> collection of AuthorEntity

        public ReaderDto Map(ReaderEntity Reader) => _mapper.Map<ReaderDto>(Reader); //ReaderEntity -> ReaderDto
        public IEnumerable<ReaderDto> Map(IEnumerable<ReaderEntity> Readers) => _mapper.Map<IEnumerable<ReaderDto>>(Readers); //Colection of ReaderEntity -> collection of ReaderDto

        public ReaderEntity Map(ReaderDto Reader) => _mapper.Map<ReaderEntity>(Reader); //ReaderDto -> ReaderEntity
        public IEnumerable<ReaderEntity> Map(IEnumerable<ReaderDto> Readers) => _mapper.Map<IEnumerable<ReaderEntity>>(Readers); //Collection of ReaderDto -> collection of ReaderEntity

        public BookDto Map(BookEntity Book) => _mapper.Map<BookDto>(Book); //BookEntity -> BookDto
        public IEnumerable<BookDto> Map(IEnumerable<BookEntity> Books) => _mapper.Map<IEnumerable<BookDto>>(Books); //Collection of BookEntity -> collection of BookDto

        public BookEntity Map(BookDto Book) => _mapper.Map<BookEntity>(Book); //BookDto -> BookEntity
        public IEnumerable<BookEntity> Map(IEnumerable<BookDto> Books) => _mapper.Map<IEnumerable<BookEntity>>(Books); //Collection of BookDto -> collection of BookEntity

        public BookTitleDto Map(BookTitleEntity BookTitle) => _mapper.Map<BookTitleDto>(BookTitle); //BookTitleEntity -> BookTitleDto
        public IEnumerable<BookTitleDto> Map(IEnumerable<BookTitleEntity> BookTitles) => _mapper.Map<IEnumerable<BookTitleDto>>(BookTitles); //Collection of BookTitleEntity -> collection of BookTitleDto

        public BookTitleEntity Map(BookTitleDto BookTitle) => _mapper.Map<BookTitleEntity>(BookTitle); //BookTitleDto -> BookTitleEntity
        public IEnumerable<BookTitleEntity> Map(IEnumerable<BookTitleDto> BookTitles) => _mapper.Map<IEnumerable<BookTitleEntity>>(BookTitles); //Collection of BookTitleDto -> collection of BookTitleEntity
    }
}
