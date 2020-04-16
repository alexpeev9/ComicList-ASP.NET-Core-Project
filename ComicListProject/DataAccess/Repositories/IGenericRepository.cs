namespace DataAccess.Repositories
{
    using DataStructure;
    public interface IGenericRepository<T> where T : Model
    {
        T GetByID(int id);
        void Delete(int id);

        void CreateOrUpdate(T entity);
    }
}
