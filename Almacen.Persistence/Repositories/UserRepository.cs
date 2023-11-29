using Almacen.Application.Contracts.Repositories;
using Almacen.Domain.EntityModels.Users;
using Almacen.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Persistence.Repositories
{
    public class UserRepository: Repository<SystemUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext): base(dbContext) 
        { 

        }
        
    }
}
