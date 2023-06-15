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

        public static BookDto ToDto(this BookEntity entity) 
            => new()
            {
                Id = entity.Id,
                Title = entity.BookTitle.Title,
                AuthorName = $"{entity.BookTitle.Author.Firstname} {entity.BookTitle.Author.Lastname}",
                PublicationYear = entity.BookTitle.PublicationYear,
                EditionPublicationYear = entity.EditionPublicationYear,
                Condition = entity.Condition,
                ConditionNote = entity.ConditionNote
            };

        public static List<BookDto> ToDto(this IEnumerable<BookEntity> entities)
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
