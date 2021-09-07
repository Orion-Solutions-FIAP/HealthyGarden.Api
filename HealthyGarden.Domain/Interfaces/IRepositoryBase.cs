namespace HealthyGarden.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        T Insert(T entity);
        T GetById(int id);
        T Update(T entity);
        void Delete(int id);
    }
}
