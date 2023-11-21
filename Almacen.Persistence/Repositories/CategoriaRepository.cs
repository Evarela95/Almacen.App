using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.Entities;
using Almacen.Persistence.Contexts;

namespace Almacen.Persistence.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
