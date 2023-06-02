using BooksLife.Core;
using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class BookViewModel
    {
        public bool IsBorrowed { get; set; } = false;
        public Guid Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        [Required]
        public Guid BookTitleId { get; set; }
        public int PublicationYear { get; set; }
        [Required]
        public int EditionPublicationYear { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        [Required]
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;
    }
}
