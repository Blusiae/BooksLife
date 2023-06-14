namespace BooksLife.Core
{
    public static class EntityToDto
    {
        public static AuthorDto ToDto(this AuthorEntity entity)
            => new()
            {
                Id = entity.Id,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname
            };

        public static List<AuthorDto> ToDto(this IEnumerable<AuthorEntity> entities)
            => entities.Select(x => x.ToDto()).ToList();

    }
}
