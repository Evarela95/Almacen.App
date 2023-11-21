using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.Entities;
using Almacen.Persistence.Contexts;

namespace Almacen.Persistence.Repositories
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
