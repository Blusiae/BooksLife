namespace BooksLife.Web
{
    public class BorrowViewModel
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        public BookViewModel? Book { get; set; }
        public ReaderViewModel? Reader { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDeadline { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
