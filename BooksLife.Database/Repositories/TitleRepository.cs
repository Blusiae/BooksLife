using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class TitleRepository : BaseRepository<BookTitleEntity>, ITitleRepository
    {
        protected override DbSet<BookTitleEntity> DbSet => _context.Titles;
        public TitleRepository(ApplicationDbContext context) : base(context) { }
    }
}
