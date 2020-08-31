using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SPAMarket.DAL.Contracts.Entities;
using SPAMarket.DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace SPAMarket.DAL.Implementations
{
    public abstract class RepositoryBase<T> : IDbRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<Guid> Add(T newEntity)
        {
            var entity = await _dbSet.AddAsync(newEntity);
            await SaveChangesAsync();
            return entity.Entity.Id;
        }

        public virtual async Task AddRange(IEnumerable<T> newEntities)
        {
            await _dbSet.AddRangeAsync(newEntities);
        }

        public virtual async Task Delete(Guid id)
        {
            var activeEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            activeEntity.IsActive = false;
            await Task.Run(() => _context.Update(activeEntity));
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> selector)
        {
            return _dbSet.Where(selector).Where(x => x.IsActive).AsQueryable();
        }

        public virtual IQueryable<T> Get()
        {
            return _dbSet.Where(x => x.IsActive).AsQueryable();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual async Task Remove(T entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));
        }

        public virtual async Task RemoveRange(IEnumerable<T> entities)
        {
            await Task.Run(() => _dbSet.RemoveRange(entities));
        }

        public virtual async Task Update(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
        }

        public virtual async Task UpdateRange(IEnumerable<T> entities)
        {
            await Task.Run(() => _dbSet.UpdateRange(entities));
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
