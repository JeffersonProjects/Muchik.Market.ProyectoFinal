using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.domain.interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> List(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IQueryable<T> Query(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T GetById(string id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entityToUpdate);
        void Update(T entityToUpdate, Func<T, string> getKey);
        void Unmark(T entity);
        IQueryable<T> Queryable();
        void Save();
    }
}
