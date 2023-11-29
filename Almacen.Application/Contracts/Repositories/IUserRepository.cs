
using Almacen.Domain.EntityModels.Users;
using Almacen.Aplication.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almacen.Application.Contracts.Repositories;

namespace Almacen.Application.Contracts.Repositories
{
    public interface IUserRepository: IRepository<SystemUser>
    {
        
    }
}
