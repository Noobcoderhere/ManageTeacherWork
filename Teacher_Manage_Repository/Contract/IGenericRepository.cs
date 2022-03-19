using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Manage_Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(bool allowTracking = true);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate, bool allowTracking = true);

        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate, bool allowTracking = true);
        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
        Task<IEnumerable<T>> GetAllAsync(bool allowTracking = true);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate, bool allowTracking = true);
        Task<T> GetByIdAsync(int id, bool allowTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool allowTracking = true);
    }
}
