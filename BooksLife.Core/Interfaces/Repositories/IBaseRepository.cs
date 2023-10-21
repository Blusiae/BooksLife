using System.Linq.Expressions;

namespace BooksLife.Core
{
    public interface IBaseRepository<Entity>
    {
        bool Create(Entity entity);
        bool Delete(Entity entity);
        Entity GetById(Guid id, params Expression<Func<Entity, object>>[] includes);
        List<Entity> GetAll(params Expression<Func<Entity, object>>[] includes);
        List<Entity> FindAll(Func<Entity, bool> filteringMethod, params Expression<Func<Entity, object>>[] includes);
        List<Entity> GetFilteredPage(Func<Entity, bool> filteringMethod, int take, int skip, params Expression<Func<Entity, object>>[] includes);
        List<Entity> GetPage(int take, int skip, params Expression<Func<Entity, object>>[] includes);
        int Count(Func<Entity, bool> filteringMethod);
        int Count();

    }
}

