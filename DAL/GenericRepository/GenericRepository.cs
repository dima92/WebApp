using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.DAL_Core.Interfaces;

namespace DAL.GenericRepository
{
    public class GenericRepository<T> where T : class
    {
        private DetailContext _dataContext;
        private readonly DbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; private set; }

        protected DetailContext DbContext
        {
            get { return _dataContext ??= DbFactory.Init(); }
        }

        protected GenericRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            DetachEntities();

            _dbSet.Add(entity); // eq  Db.Set<T>().Attach(entity); 
            _dataContext.Entry(entity).State = EntityState.Added;
            _dataContext.SaveChanges();
        }

        public virtual T AddWithReturn(T entity)
        {
            DetachEntities();

            _dbSet.Add(entity); // eq  Db.Set<T>().Attach(entity); 
            _dataContext.Entry(entity).State = EntityState.Added;
            _dataContext.SaveChanges();
            return entity;
        }

        private void DetachEntities()
        {
            var objectStateEntries =
                _dataContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Unchanged);
            foreach (var objectStateEntry in objectStateEntries)
            {
                objectStateEntry.State = EntityState.Detached;
            }
        }

        public virtual T Update(T entity, decimal key)
        {
            T existing = _dataContext.Set<T>().Find(key);
            if (existing != null)
            {
                _dataContext.Entry(existing).CurrentValues.SetValues(entity);
                _dataContext.SaveChanges();
            }
            return existing;
        }


        public virtual void UpdateVoid(T entity, decimal key)
        {
            T existing = _dataContext.Set<T>().Find(key);
            if (existing != null)
            {
                _dataContext.Entry(existing).CurrentValues.SetValues(entity);
                _dataContext.SaveChanges();
            }
        }


        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dataContext.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Single(Expression<Func<T, bool>> match)
        {
            return _dbSet.SingleOrDefault(match);
        }

        public T First(Expression<Func<T, bool>> match)
        {
            return _dbSet.FirstOrDefault(match);
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }


        public IQueryable<T> GetAllWithPaging<TKey>(int pageSize, int page, out int total, Expression<Func<T, TKey>> orderBy, bool isOrderAsc, Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> resultFromDb = _dbSet.Where(filter);
            total = resultFromDb.Count();

            IQueryable<T> resultForPaging = isOrderAsc ? resultFromDb.OrderBy(orderBy).Skip((page - 1) * pageSize).Take(pageSize) : resultFromDb.OrderByDescending(orderBy).Skip((page - 1) * pageSize).Take(pageSize);

            return resultForPaging;
        }
    }
}