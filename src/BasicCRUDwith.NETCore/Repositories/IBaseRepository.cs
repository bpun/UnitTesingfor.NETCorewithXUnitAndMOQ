using System.Linq;

namespace BasicCRUDwith.NETCore.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        void Commit();
    }
}
