using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Repository.Repository.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MTWDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(MTWDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public void Delete(T entity)
        {
            _db.Attach(entity);
            _db.Remove(entity);
        }

        public void Delete(int id)
        {
            T entity = _db.Find(id);
            Delete(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> predicate, bool allowTracking = true)
        {
            if(!allowTracking)
                return _db.AsNoTracking().FirstOrDefault(predicate);
            return _db.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(bool allowTracking = true)
        {
            if(!allowTracking)
                return _db.AsNoTracking().AsEnumerable();
            return _db.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool allowTracking = true)
        {
            if(!allowTracking)
                return await _db.AsNoTracking().ToListAsync();
            return await _db.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool allowTracking = true)
        {
            if(!allowTracking)
                return await _db.AsNoTracking().FirstOrDefaultAsync(predicate);
            return await _db.FirstOrDefaultAsync(predicate);
        }

        public T GetById(int id)
        {    
            return _db.Find(id);
            //return _db.FirstOrDefault(x => (int)x.GetType().GetProperty("ID").GetValue(x) == id);
        }

        public async Task<T> GetByIdAsync(int id, bool allowTracking = true)
        {
            if(!allowTracking)
                return await _db.AsNoTracking().FirstOrDefaultAsync(x => (int)x.GetType().GetProperty("ID").GetValue(x) == id);
            return await _db.FindAsync(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate, bool allowTracking = true)
        {
            if(!allowTracking)
                return _db.AsNoTracking().Where(predicate).AsEnumerable();
            return _db.Where(predicate).AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate, bool allowTracking = true)
        {
            if(!allowTracking)
                return await _db.AsNoTracking().Where(predicate).ToListAsync();
            return await _db.Where(predicate).ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
