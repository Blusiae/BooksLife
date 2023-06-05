namespace BooksLife.Core
{
    public static class EntityMapExtensions
    {
        public static AuthorEntity ToEntity(this AuthorDto authorDto)
        {
            return new AuthorEntity()
            {
                Id = authorDto.Id,
                Firstname = authorDto.Firstname,
                Lastname = authorDto.Lastname
            };
        }

        public static List<AuthorEntity> ToEntity(this IEnumerable<AuthorDto> authorDtos)
        {
            return authorDtos.Select(x => ToEntity(x)).ToList();
        }
    }
}
