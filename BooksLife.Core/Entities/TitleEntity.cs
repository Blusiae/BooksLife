namespace BooksLife.Core
{
    public class TitleEntity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }

        public Guid AuthorId { get; set; }
        public virtual AuthorEntity Author { get; set; }

        public virtual IEnumerable<BookEntity> Books { get; set; }

    }
}
