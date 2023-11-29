using Almacen.Application.Contracts.Contexts;
using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.Entities;
using Almacen.Domain.EntityModels.Users;
using Almacen.Persistence.Contexts;
using Almacen.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Almacen.Persistence
{
    public static class Injection
    {
        public static IServiceCollection AddPersistence
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IApplicationDbContext>
                (options => options.GetService<ApplicationDbContext>());

            services.AddRepository<Categoria, ICategoriaRepository, CategoriaRepository>();
            services.AddRepository<Marca, IMarcaRepository, MarcaRepository>();
            services.AddRepository<Producto, IProductoRepository, ProductoRepository>();
            services.AddRepository<Producto_Sucursal, IProducto_SucursalRepository, Producto_SucursalRepository>();
            services.AddRepository<Proveedor, IProveedorRepository, ProveedorRepository>();
            services.AddRepository<Sucursal, ISucursalRepository, SucursalRepository>();
            services.AddRepository<SystemUser, IUserRepository, UserRepository>();
            return services;
        }
    }
}
