using System.Linq.Expressions;

namespace BooksLife.Core
{
    public interface IBaseRepository<Entity>
    {
        bool Create(Entity entity);
        bool Delete(Entity entity);
        Entity? GetById(Guid id);
        IEnumerable<Entity> GetAll();
        IEnumerable<Entity> FindAll(Func<Entity, bool> filteringMethod);
        IEnumerable<Entity> GetFilteredPage(Func<Entity, bool> filteringMethod, int take, int skip);
        IEnumerable<Entity> GetPage(int take, int skip);
        int Count(Func<Entity, bool> filteringMethod);
        int Count();

    }
}

