namespace BooksLife.Core
{
    public class BookEntity : BaseEntity
    {
        public Guid TitleId { get; set; }
        public virtual TitleEntity Title { get; set; }

        public int EditionPublicationYear { get; set; }
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;

    }
}
