namespace BooksLife.Core
{
    public class TitleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public AuthorDto Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
