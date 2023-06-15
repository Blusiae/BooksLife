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

        public static BookTitleDto ToDto(this BookTitleEntity entity)
            => new()
            {
                Id = entity.Id,
                Title = entity.Title,
                PublicationYear = entity.PublicationYear,
                AuthorName = $"{entity.Author.Firstname} {entity.Author.Lastname}"
            };

        public static List<BookTitleDto> ToDto(this IEnumerable<BookTitleEntity> entities)
            => entities.Select(x => x.ToDto()).ToList();

    }
}
