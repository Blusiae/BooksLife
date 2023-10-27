namespace BooksLife.Core
{
    public class BookTitleEntity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }

        public Guid AuthorId { get; set; }
        public AuthorEntity? Author { get; set; }

        public List<BookEntity> Books { get; set; } = new List<BookEntity>();

    }
}
