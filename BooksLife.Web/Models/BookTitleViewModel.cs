using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class BookTitleViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int PublicationYear { get; set; }
        public string? AuthorName { get; set; } = string.Empty;
        [Required]
        public Guid AuthorId { get; set; }
    }
}
