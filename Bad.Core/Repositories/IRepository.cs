using Bad.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bad.Core.Repositories
{
    public interface IRepository<TEntity, TIdType> :IDisposable
        where TEntity : BaseEntityModel<TIdType>
    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetByIDAsync(TIdType id);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        Task<int> SaveChangesAsync();
        bool Exists(TIdType id);
    }
    public interface IRepository<TEntity> :IDisposable
        where TEntity : BaseEntityModel
    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        void Insert(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        Task<int> SaveChangesAsync();
    }
}
