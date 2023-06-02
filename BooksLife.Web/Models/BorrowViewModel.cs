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
        public BookViewModel Book { get; set; } = new BookViewModel();
        [Required]
        public Guid ReaderId { get; set; }
        public ReaderViewModel Reader { get; set; } = new ReaderViewModel();
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
