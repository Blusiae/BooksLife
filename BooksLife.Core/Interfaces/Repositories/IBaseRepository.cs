namespace BooksLife.Core
{
    public interface IBaseRepository<Entity>
    {
        bool Add(Entity entity);
        bool Remove(int id);
        IEnumerable<Entity> GetAll();
        Entity Get(int id);
    }
}

