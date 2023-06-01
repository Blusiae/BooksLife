namespace BooksLife.Core
{
    public class BorrowDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; } = new BookEntity();
        public Guid ReaderId { get; set; }
        public ReaderEntity Reader { get; set; } = new ReaderEntity();
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
