using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepository
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);

        bool Add(IEnumerable<T> items);

        bool Update(T entity);

        bool Update(IEnumerable<T> items);

        bool Delete(T entity);

        bool Delete(IEnumerable<T> entities);

        IQueryable<T> All();

        T FindBy(Expression<Func<T, bool>> expression);

        T FindBy(int id);

        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);
    }
}
