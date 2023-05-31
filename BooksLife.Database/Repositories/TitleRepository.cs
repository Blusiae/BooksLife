using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class TitleRepository : BaseRepository<TitleEntity>, ITitleRepository
    {
        protected override DbSet<TitleEntity> DbSet => _context.Titles;
        public TitleRepository(ApplicationDbContext context) : base(context) { }
    }
}
