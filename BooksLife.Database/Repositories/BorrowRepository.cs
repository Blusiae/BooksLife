using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class BorrowRepository : BaseRepository<BorrowEntity>, IBorrowRepository
    {
        protected override DbSet<BorrowEntity> DbSet => _context.Borrows;
        public BorrowRepository(ApplicationDbContext context) : base(context) { }

        public bool SetAsUnactive(Guid id)
        {
            var borrow = _context.Borrows.FirstOrDefault(x => x.Id == id);
            if (borrow != null)
            {
                borrow.IsActive = false;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool SetAsActive(Guid id)
        {
            var borrow = _context.Borrows.FirstOrDefault(x => x.Id == id);
            if (borrow != null)
            {
                borrow.IsActive = true;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
