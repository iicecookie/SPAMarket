using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using SPAMarket.DAL.Contracts.Entities;

namespace SPAMarket.DAL.Contracts
{
    public interface IDbRepository<T> where T : class, IEntity
    {
        IQueryable<T> Get(Expression<Func<T, bool>> selector);
        IQueryable<T> Get();
        IQueryable<T> GetAll();

        Task<Guid> Add(T newEntity);
        Task  AddRange(IEnumerable<T> newEntities);

        Task Delete(Guid id);

        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);

        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
            
        Task<int> SaveChangesAsync();
    }
}
