using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Proveedor
{
    public class NewProveedor
    {
        public NewProveedor()
        {
            
        }


        public string Nombre_Proveedor { get; private set; }

 
        public string Telefono { get; private set; }

        public string Correo { get; private set; }

    }
}
