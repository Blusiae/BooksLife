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
    }
}
