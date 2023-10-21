namespace BooksLife.Core
{
    public class BorrowEntity : BaseEntity
    {
        public bool IsActive { get; set; }
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }
        public Guid ReaderId { get; set; }
        public ReaderEntity Reader { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
