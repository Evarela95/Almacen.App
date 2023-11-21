using Almacen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Application.Contracts.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Marca> Marcas { get; set; }
        DbSet<Producto> Productos { get; set; }
        DbSet<Producto_Sucursal> Productos_Sucursales { get; set; }
        DbSet<Proveedor> Proveedores { get; set; }
        DbSet<Sucursal> Sucursales { get; set; }

        void Save();
    }
}
