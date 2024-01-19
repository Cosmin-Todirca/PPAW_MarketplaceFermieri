using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Accesor
{
    public class BaseAccesor<TObject> where TObject : class
    {
        protected DbContext _dbContext;

        public BaseAccesor(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<TObject> GetAll()
        {
            return _dbContext.Set<TObject>().ToList();
        }

        public IQueryable<TObject> GetAllQuerable()
        {
            return _dbContext.Set<TObject>();

        }

        public async Task<ICollection<TObject>> GetAllAsync()
        {
            return await _dbContext.Set<TObject>().ToListAsync();
        }

        public TObject Get(int key)
        {
            return _dbContext.Set<TObject>().Find(key);
        }

        public TObject Get(string key)
        {
            return _dbContext.Set<TObject>().Find(key);
        }

        public async Task<TObject> GetAsync(int key)
        {
            return await _dbContext.Set<TObject>().FindAsync(key);
        }

        public TObject Find(Expression<Func<TObject, bool>> match)
        {
            return _dbContext.Set<TObject>().FirstOrDefault(match);
        }

        public async Task<TObject> FindAsync(Expression<Func<TObject, bool>> match)
        {
            return await _dbContext.Set<TObject>().SingleOrDefaultAsync(match);
        }

        public ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match)
        {
            return _dbContext.Set<TObject>().Where(match).ToList();
        }
        public IQueryable<TObject> FindAllQuerable(Expression<Func<TObject, bool>> match)
        {
            return _dbContext.Set<TObject>().Where(match);
        }

        public async Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match)
        {
            return await _dbContext.Set<TObject>().Where(match).ToListAsync();
        }

        public TObject Add(TObject t)
        {
            _dbContext.Set<TObject>().Add(t);

            _dbContext.SaveChanges();

            return t;
        }

        public ICollection<TObject> AddRange(ICollection<TObject> t)
        {
            ICollection<TObject> inserted = _dbContext.Set<TObject>().AddRange(t).ToList();
            _dbContext.SaveChanges();
            return inserted;
        }


        public async Task<TObject> AddAsync(TObject t)
        {
            _dbContext.Set<TObject>().Add(t);
            await _dbContext.SaveChangesAsync();
            return t;
        }



        public TObject Update(TObject updated, int key)
        {
            if (updated == null)
                return null;

            TObject existing = _dbContext.Set<TObject>().Find(key);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(updated);
                _dbContext.SaveChanges();
            }
            return existing;
        }

        public TObject Update(TObject updated, string key)
        {
            if (updated == null)
                return null;

            TObject existing = _dbContext.Set<TObject>().Find(key);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(updated);
                _dbContext.SaveChanges();
            }
            return existing;
        }

        public async Task<TObject> UpdateAsync(TObject updated, int key)
        {
            if (updated == null)
                return null;

            TObject existing = await _dbContext.Set<TObject>().FindAsync(key);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(updated);
                await _dbContext.SaveChangesAsync();
            }
            return existing;
        }

        public void Delete(TObject t)
        {
            _dbContext.Set<TObject>().Remove(t);
            _dbContext.SaveChanges();
        }

        public void DeleteRange(ICollection<TObject> t)
        {
            _dbContext.Set<TObject>().RemoveRange(t);
            _dbContext.SaveChanges();
        }

        public async Task<int> DeleteAsync(TObject t)
        {
            _dbContext.Set<TObject>().Remove(t);
            return await _dbContext.SaveChangesAsync();
        }

        public int Count()
        {
            return _dbContext.Set<TObject>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<TObject>().CountAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
