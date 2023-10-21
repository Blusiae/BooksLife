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

        private IQueryable<Entity> GetQueryWithIncludes(params Expression<Func<Entity, object>>[] includes)
        {
            var baseQuery = DbSet.AsQueryable();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    baseQuery = baseQuery.Include(include);
                }
            }

            return baseQuery;
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

        public Entity GetById(Guid id, params Expression<Func<Entity, object>>[] includes)
        {
            var baseQuery = GetQueryWithIncludes(includes);

            return baseQuery.FirstOrDefault(x => x.Id == id);
        }

        public List<Entity> GetAll(params Expression<Func<Entity, object>>[] includes)
        {
            var baseQuery = GetQueryWithIncludes(includes);

            return baseQuery
                .ToList();
        }

        public List<Entity> GetFilteredPage(Func<Entity, bool> filteringMethod, int take, int skip, params Expression<Func<Entity, object>>[] includes)
        {
            var baseQuery = GetQueryWithIncludes(includes);

            return baseQuery
                .Where(filteringMethod)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Entity> GetPage(int take, int skip, params Expression<Func<Entity, object>>[] includes)
        {
            var baseQuery = GetQueryWithIncludes(includes);

            return baseQuery
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Entity> FindAll(Func<Entity, bool> filteringMethod, params Expression<Func<Entity, object>>[] includes)
        {
            var baseQuery = GetQueryWithIncludes(includes);

            return baseQuery
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
