using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class AddBorrowViewModel
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid ReaderId { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
