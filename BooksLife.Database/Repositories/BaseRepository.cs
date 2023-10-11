using BooksLife.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

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
        public bool Create(Entity entity)
        {
            DbSet.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Entity entity)
        {
            DbSet.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public Entity? GetById(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Entity> GetAll()
        {
            return DbSet
                .ToList();
        }

        public IEnumerable<Entity> GetFilteredPage(Func<Entity, bool> filteringMethod, int take, int skip)
        {
            return DbSet
                .Where(filteringMethod)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public IEnumerable<Entity> GetPage(int take, int skip)
        {
            return DbSet
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public IEnumerable<Entity> FindAll(Func<Entity, bool> filteringMethod)
        {
            return DbSet
                .Where(filteringMethod)
                .ToList();
        }

        public int Count(Func<Entity, bool> filteringMethod)
        {
            return DbSet.Count(filteringMethod);
        }

        public int Count()
        {
            return DbSet.Count();
        }

    }
}
