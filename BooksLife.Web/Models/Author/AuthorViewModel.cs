namespace BooksLife.Web
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string Lastname { get; set; } = string.Empty;
    }
}
