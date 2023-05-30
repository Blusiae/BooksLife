namespace BooksLife.Core
{
    public interface IBaseRepository<Entity>
    {
        bool Add(Entity entity);
        bool Remove(Guid id);
        IEnumerable<Entity> GetAll();
        Entity Get(Guid id);
    }
}

