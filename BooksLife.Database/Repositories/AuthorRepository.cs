using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
    {
        protected override DbSet<AuthorEntity> DbSet => _context.Authors;

        public AuthorRepository(ApplicationDbContext context) : base(context) { }
    }
}
