using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Application.Components
{
    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message {  get; }
    }

    public class Errors
    {
        public static Error None => new Error(string.Empty);

        public static Error NotFound => new Error("Not record has been found.");
    }
}
