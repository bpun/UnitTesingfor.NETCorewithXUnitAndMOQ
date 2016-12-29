using System;
using System.Linq;
using BasicCRUDwith.NETCore.DbContexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUDwith.NETCore.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly StudentContext _context;
        public BaseRepository(StudentContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Entry(entity);
                _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().AsNoTracking().AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                var dbEntityEntry = _context.Entry(entity);
                dbEntityEntry.State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual void Delete(T entity)
        {
            try
            {

                EntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
