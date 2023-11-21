using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.Entities;
using Almacen.Persistence.Contexts;

namespace Almacen.Persistence.Repositories
{
    public class Producto_SucursalRepository : Repository<Producto_Sucursal>, IProducto_SucursalRepository
    {
        public Producto_SucursalRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
