using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.Entities;
using Almacen.Domain.EntityModels;
using Microsoft.Extensions.DependencyInjection;

namespace Almacen.Persistence.Repositories
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepository<TEntity, TContract, TRepository>
            (this IServiceCollection services)
            where TEntity : Entity
            where TContract : class, IRepository<TEntity>
            where TRepository : class, TContract
        {
            services.AddScoped<TContract, TRepository>();
            return services;
        }
    }
}

