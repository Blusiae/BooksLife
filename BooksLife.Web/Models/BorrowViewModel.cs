using BooksLife.Core;
using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class BorrowViewModel
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        [Required]
        public Guid BookId { get; set; }
        public BookViewModel? Book { get; set; }
        [Required]
        public Guid ReaderId { get; set; }
        public ReaderViewModel? Reader { get; set; }
        public DateTime BorrowDate { get; set; } = new DateTime();
        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
