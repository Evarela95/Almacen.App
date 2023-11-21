using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.Entities;
using Almacen.Persistence.Contexts;

namespace Almacen.Persistence.Repositories
{
    public class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
