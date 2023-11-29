using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Infrastructure.Authorization
{
    public static class PolicyTypes
    {
        //Tareas que le quiero dar
        public static class Guests { 
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
            public const string Read = "Read";
        }
    }
}
