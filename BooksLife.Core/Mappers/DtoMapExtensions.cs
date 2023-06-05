namespace BooksLife.Core
{
    public static class DtoMapExtensions
    {
       public static AuthorDto ToDto(this AuthorEntity authorEntity)
        {
            return new AuthorDto()
            {
                Id = authorEntity.Id,
                Firstname = authorEntity.Firstname,
                Lastname = authorEntity.Lastname
            };
        }

        public static List<AuthorDto> ToDto(this IEnumerable<AuthorEntity> authorEntities)
        {
            return authorEntities.Select(x => x.ToDto()).ToList();
        }
    }
}
