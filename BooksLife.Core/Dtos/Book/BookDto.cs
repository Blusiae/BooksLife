namespace BooksLife.Core
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public bool IsBorrowed { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public int EditionPublicationYear { get; set; }
        public string AuthorName { get; set; }
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;
    }
}
