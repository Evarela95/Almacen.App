
using Almacen.Domain.Entities;
using System.Linq.Expressions;


namespace Almacen.Application.Contracts.Repositories
{
    public interface IRepository<TEntity>
             where TEntity : Entity
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);
        //Multiples expresiones como pilas, colas
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();

    }
}
