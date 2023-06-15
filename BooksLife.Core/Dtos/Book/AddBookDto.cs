namespace BooksLife.Core
{
    public class AddBookDto
    {
        public bool IsBorrowed { get; set; }
        public Guid BookTitleId { get; set; }
        public int EditionPublicationYear { get; set; }
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;
    }
}
