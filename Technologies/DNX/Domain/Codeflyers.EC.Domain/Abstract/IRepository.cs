using System;
using System.Linq;
using System.Linq.Expressions;

namespace Codeflyers.EC.Domain.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T AddOrUpdate(T entity);
        T GetByCode(string code);
        T GetById(long id);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        //IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Remove(int id);
        T Remove(T obj);
        T Remove(Expression<Func<T, bool>> where);
        void Save();
    }
}
