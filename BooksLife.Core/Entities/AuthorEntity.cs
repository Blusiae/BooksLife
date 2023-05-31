namespace BooksLife.Core
{
    public class AuthorEntity: BaseEntity
    {
        public string? Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;

        public virtual IEnumerable<TitleEntity>? Titles { get; set; }
    }
}
