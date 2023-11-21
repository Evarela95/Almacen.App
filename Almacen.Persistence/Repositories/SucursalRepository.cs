using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.Entities;
using Almacen.Persistence.Contexts;

namespace Almacen.Persistence.Repositories
{
    public class SucursalRepository : Repository<Sucursal>, ISucursalRepository
    {
        public SucursalRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
