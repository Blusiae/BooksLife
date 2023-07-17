using BooksLife.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BooksLife.Database
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        protected ApplicationDbContext _context;
        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public bool Add(Entity entity)
        {
            DbSet.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Entity entity)
        {
            DbSet.Update(entity);
            return _context.SaveChanges() > 0;
        }

        public Entity Get(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Entity> GetAll(int take, int skip = 0)
        {
            return DbSet
                .Skip(skip)
                .Take(take);
        }

        public int Count()
        {
            return DbSet.Count();
        }

        public bool Remove(Guid id)
        {
            var entityToDelete = DbSet.FirstOrDefault(x =>x.Id == id);
            if (entityToDelete != null) //Check if entity has been found in database.
            {
                DbSet.Remove(entityToDelete);
                return _context.SaveChanges() > 0;
            }

            return false; //Entity not found, so it's not been deleted.
        }
    }
}
