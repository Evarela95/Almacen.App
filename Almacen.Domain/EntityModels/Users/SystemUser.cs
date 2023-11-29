using Almacen.Domain.Entities;
using Almacen.Domain.EntityModels.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.EntityModels.Users
{
    public class SystemUser : Entity
    {
        private SystemUser()
        {
            Permissions = new List<PolicyPermission>();
        }
        public SystemUser(string email)
            : this()
        {
            Email = email;
        }
        [Key]
        public string Email { get; private set; }
        public IList<PolicyPermission> Permissions { get; private set; }
    }
}
