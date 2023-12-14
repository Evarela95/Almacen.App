using Almacen.Application.Contracts.Repositories;
using Almacen.Application.Diagnostics;
using Almacen.Domain.Entities;
using Almacen.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Almacen.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbset;

        public Repository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbset = this._dbContext.Set<TEntity>();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbset;
            query = query.Where(predicate);

            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbset;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes.Any())
            {
                query = includes.Aggregate
                    (query, (current, include) => current.Include(include));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public void Insert(TEntity entity)
        {
            Guard.Against.ThrowIfNull(entity);
            _dbset.Add(entity);
        }

        public void Update(TEntity entity)
        {
            Guard.Against.ThrowIfNull(entity);
            _dbset.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Guard.Against.ThrowIfNull(entity);
            _dbset.Remove(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
