using AutoMapper;

namespace BooksLife.Core
{
    public class DtoMapper
    {
        private IMapper _mapper;

        public DtoMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<AuthorEntity, AuthorDto>().ReverseMap();
            }).CreateMapper();
        }

        public AuthorDto Map(AuthorEntity Author) => _mapper.Map<AuthorDto>(Author); //AuthorEntity -> AuthorDto
        public IEnumerable<AuthorDto> Map(IEnumerable<AuthorEntity> Authors) => _mapper.Map<IEnumerable<AuthorDto>>(Authors); //Collection of AuthorEntity -> collection of AuthorDto

        public AuthorEntity Map(AuthorDto Author) => _mapper.Map<AuthorEntity>(Author); //AuthorDto -> AuthorEntity
        public IEnumerable<AuthorEntity> Map(IEnumerable<AuthorDto> Authors) => _mapper.Map<IEnumerable<AuthorEntity>>(Authors); //Collection of AuthorDto -> collection of AuthorEntity
    }
}
