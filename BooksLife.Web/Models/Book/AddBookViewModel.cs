using BooksLife.Core;
using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class AddBookViewModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public Guid AuthorId { get; set; }
        public int PublicationYear { get; set; }
        public int EditionPublicationYear { get; set; }
        [Required]
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;
    }
}
