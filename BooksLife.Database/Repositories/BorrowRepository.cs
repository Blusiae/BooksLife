using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class BorrowRepository : BaseRepository<BorrowEntity>, IBorrowRepository
    {
        protected override DbSet<BorrowEntity> DbSet => _context.Borrows;
        public BorrowRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<BorrowEntity> GetAll()
        {
            return DbSet.Select(x => x);
        }
    }
}
