using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class BookRepository : BaseRepository<BookEntity>, IBookRepository
    {
        protected override DbSet<BookEntity> DbSet => _context.Books;

        public BookRepository(ApplicationDbContext context) : base(context) { }

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
