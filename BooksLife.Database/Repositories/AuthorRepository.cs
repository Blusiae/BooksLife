using BooksLife.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BooksLife.Database
{
    public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
    {
        protected override DbSet<AuthorEntity> DbSet => _context.Authors;

        public AuthorRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<AuthorEntity> GetAll(out int totalCount, int take, int skip = 0, string? filterString = null)
        {
            var filteringMethod = new Func<AuthorEntity, bool>(x => filterString.IsNullOrEmpty() 
            || string.Join(' ', x.Firstname, x.Lastname).ToLower().Contains(filterString.ToLower()));

            totalCount = Count(filteringMethod);

            return GetAll(filteringMethod, take, skip);
        }
    }
}
