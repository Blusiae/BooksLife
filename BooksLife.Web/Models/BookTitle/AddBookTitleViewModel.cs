using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class AddBookTitleViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
