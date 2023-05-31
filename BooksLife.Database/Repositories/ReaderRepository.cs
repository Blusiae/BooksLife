using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class ReaderRepository : BaseRepository<ReaderEntity>, IReaderRepository
    {
        protected override DbSet<ReaderEntity> DbSet => _context.Readers;
        public ReaderRepository(ApplicationDbContext context) : base(context) { }
    }
}
