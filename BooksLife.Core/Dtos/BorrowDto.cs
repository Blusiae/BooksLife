namespace BooksLife.Core
{
    public class BorrowDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public BookDto Book { get; set; } = new BookDto();
        public Guid ReaderId { get; set; }
        public ReaderDto Reader { get; set; } = new ReaderDto();
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
