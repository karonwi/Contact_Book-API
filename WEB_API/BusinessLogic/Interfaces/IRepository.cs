
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRepository<T> where T : class,new ()
    {
        Task<T> Get(string id);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        
        bool AddAsync(T entity);
        bool AddRangeAsync(IEnumerable<T> entities);
        bool Update(T entity);

        bool Delete(T entity);
        bool DeleteRange(IEnumerable<T> entities);
    }
}
