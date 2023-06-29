﻿using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class AddBorrowViewModel
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid ReaderId { get; set; }
        public DateTime BorrowDate { get; set; } = new DateTime();
        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
