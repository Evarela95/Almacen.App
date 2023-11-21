using Almacen.Application.Contracts.Contexts;
using Almacen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Producto_Sucursal> Productos_Sucursales { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
