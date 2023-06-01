namespace BooksLife.Core
{
    public class BookTitleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public string? AuthorName { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
    }
}
