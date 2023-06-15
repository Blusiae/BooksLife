namespace BooksLife.Core
{
    public class AddBookTitleDto
    {
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public Guid AuthorId { get; set; }
    }
}
