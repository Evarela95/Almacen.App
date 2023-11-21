
using Almacen.Application.Contracts;
using Almacen.Application.Diagnostics;
using Almacen.Application.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Almacen.Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplication
            (this IServiceCollection services, IConfiguration configuration)
        {
          
            //var assembly = typeof(Injection).Assembly;

            //services.AddMediatR(options => options.RegisterServicesFromAssemblies(assembly));
            //services.AddValidatorsFromAssembly(assembly);



            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IProducto_SucursalService, Producto_SucursalService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<ISucursalService, SucursalService>();

            return services;
        }
    }
}
