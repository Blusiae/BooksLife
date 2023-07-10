using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class BookRepository : BaseRepository<BookEntity>, IBookRepository
    {
        protected override DbSet<BookEntity> DbSet => _context.Books;

        public BookRepository(ApplicationDbContext context) : base(context) { }

        public new bool Add(BookEntity entity)
        {
            var bookTitle = _context.BookTitles.FirstOrDefault(x => x.Title == entity.BookTitle.Title
                && x.PublicationYear == entity.BookTitle.PublicationYear
                && x.AuthorId == entity.BookTitle.AuthorId);

            if(bookTitle != null)
            {
                entity.BookTitle = bookTitle;
            }

            DbSet.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool SetAsBorrowed(Guid id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            book.IsBorrowed = true;
            return _context.SaveChanges() > 0;
        }

        public bool SetAsUnborrowed(Guid id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            book.IsBorrowed = false;
            return _context.SaveChanges() > 0;
        }
    }
}
