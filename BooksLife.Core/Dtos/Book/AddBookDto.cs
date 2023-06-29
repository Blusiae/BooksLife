namespace BooksLife.Core
{
    public class AddBookDto
    {
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public Guid AuthorId { get; set; }
        public int EditionPublicationYear { get; set; }
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;
    }
}
