using BooksLife.Core;
using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class AddBookViewModel
    {
        [Required]
        public Guid BookTitleId { get; set; }
        public int EditionPublicationYear { get; set; }
        [Required]
        public BookCondition Condition { get; set; }
        public string? ConditionNote { get; set; } = string.Empty;
    }
}
