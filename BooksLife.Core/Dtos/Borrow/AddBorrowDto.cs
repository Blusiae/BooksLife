namespace BooksLife.Core
{
    public class AddBorrowDto
    {
        public Guid BookId { get; set; }
        public Guid ReaderId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
