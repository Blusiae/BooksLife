namespace BooksLife.Core
{
    public static class DtoToEntity
    {
        public static AuthorEntity ToEntity(this AddAuthorDto dto)
            => new()
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };

        public static List<AuthorEntity> ToEntity(this IEnumerable<AddAuthorDto> dtos)
            => dtos.Select(x => x.ToEntity()).ToList();

    }
}
