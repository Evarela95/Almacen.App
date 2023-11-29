using Almacen.Domain.EntityModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.EntityModels.Authorization
{
    public class PolicyPermission
    {
        private PolicyPermission()
        {
            Users = new List<SystemUser>();
        }
        public PolicyPermission(string controller, string action)
        {
            Controller = controller;
            Action = action;
        }
        [Key]
        public int Id { get; set; }
        public string Controller {  get; private set; }
        public string Action { get; private set; }
        public IList<SystemUser> Users { get; private set; }
    }
}
