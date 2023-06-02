namespace BooksLife.Core
{
    public class BookEntity : BaseEntity
    {
        public bool IsBorrowed { get; set; }

        public Guid BookTitleId { get; set; }
        public virtual BookTitleEntity BookTitle { get; set; }

        public int EditionPublicationYear { get; set; }
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;

        public virtual List<BorrowEntity>? Borrows { get; set; }

    }
}
