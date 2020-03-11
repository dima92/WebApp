using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        T AddWithReturn(T entity);
        T Update(T entity, decimal key);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(int id);
        T Single(Expression<Func<T, bool>> match);
        T First(Expression<Func<T, bool>> match);
        bool Any(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> where);
        void UpdateVoid(T entity, decimal key);

        IQueryable<T> GetAllWithPaging<TKey>(int pageSize, int page, out int total,
            Expression<Func<T, TKey>> orderBy, bool isOrderAsc,
            Expression<Func<T, bool>> filter = null);
    }
}
