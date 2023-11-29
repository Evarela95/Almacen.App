using Almacen.Domain.EntityModels.Authorization;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Infrastructure.Authorization
{
    public class PolicyRequirement : IAuthorizationRequirement
    {
        private readonly IEnumerable<PolicyPermission> _permissions;

        public PolicyRequirement(IEnumerable<PolicyPermission> permissions)
        {
            this._permissions = permissions;
        }
        public IReadOnlyList<PolicyPermission> Permissions
        {
            get { 
                return _permissions.ToList();
            }
        }
    }
}
