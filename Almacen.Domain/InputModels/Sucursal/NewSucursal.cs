using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Sucursal
{
    public class NewSucursal
    {
        public NewSucursal()
        {
            
        }

        public string Nombre_Sucursal { get; private set; }

        public string Telefono { get; private set; }


        public string Correo { get; private set; }



        public string Direccion { get; private set; }




    }
}
