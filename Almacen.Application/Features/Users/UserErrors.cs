using Almacen.Application.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Application.Features.Users
{
    public class UserErrors : Errors
    {
        public static Error NotCreated => new Error("User could not be created.");
    }
}
