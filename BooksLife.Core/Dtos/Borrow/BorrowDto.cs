namespace BooksLife.Core
{
    public class BorrowDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public BookDto Book { get; set; } = new BookDto();
        public ReaderDto Reader { get; set; } = new ReaderDto();
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
