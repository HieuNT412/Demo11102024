using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Demo1110.Model;
using Demo1110.Repository;
using Microsoft.EntityFrameworkCore;

namespace Demo1110.IRepository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext _db;

        public RepositoryBase(AppDbContext db){
            _db = db;
        }

        public void Create(T entity) => _db.Set<T>().Add(entity);

        public void Delete(T entity) => _db.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? _db.Set<T>().AsNoTracking() : _db.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ? _db.Set<T>().Where(expression).AsNoTracking() : _db.Set<T>().Where(expression);

        public void Update(T entity) => _db.Set<T>().Update(entity);
    }
}