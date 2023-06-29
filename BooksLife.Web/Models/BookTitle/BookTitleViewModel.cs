using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class BookTitleViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public string? AuthorName { get; set; } = string.Empty;
    }
}
