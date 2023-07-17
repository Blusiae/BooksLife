namespace BooksLife.Core
{
    public interface IBaseRepository<Entity>
    {
        bool Add(Entity entity);
        bool Remove(Guid id);
        bool Update(Entity entity);
        IEnumerable<Entity> GetAll(int take, int skip = 0);
        int Count();
        Entity Get(Guid id);
    }
}

