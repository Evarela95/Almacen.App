
using Almacen.Domain.Entities;
using System.Linq.Expressions;


namespace Almacen.Application.Contracts.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, 
            params Expression<Func<TEntity, object>>[] includes);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Save();
    }
}
