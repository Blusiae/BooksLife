using BooksLife.Core;

namespace BooksLife.Web
{
    public class BookViewModel
    {
        public bool IsBorrowed { get; set; } = false;
        public Guid Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public int EditionPublicationYear { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;
    }
}
