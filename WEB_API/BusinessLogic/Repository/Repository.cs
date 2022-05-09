using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repository
{
    public class Repository<T> : IRepository<T> where T : class,new()
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<T> Get(string id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().ToListAsync();
        }

        public bool AddAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            return _context.SaveChanges() > 0;
        }

        public bool AddRangeAsync(IEnumerable<T> entities)
        {
            if (entities != null)
            {
                _context.Set<T>().AddRangeAsync(entities);
                  _context.SaveChanges();
                  return true;
            }
            return false;
        }

        public bool Update(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteRange(IEnumerable<T> entities)
        {
            if (entities != null)
            {
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
