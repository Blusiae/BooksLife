namespace BooksLife.Core
{
    public interface IBaseRepository<Entity>
    {
        bool Add(Entity entity);
        bool Remove(Guid id);
        bool Update(Entity entity);
        IEnumerable<Entity> GetAll(int take, int skip = 0);
        IEnumerable<Entity> GetAll(Func<Entity, bool> filteringMethod, int take, int skip = 0);
        int Count();
        int Count(Func<Entity, bool> filteringMethod);
        Entity Get(Guid id);
    }
}

