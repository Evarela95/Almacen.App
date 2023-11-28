using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
       
        [DisplayName("Nombre de sucursal")]
        public string Nombre_Sucursal { get;  set; }


        [Required]
        public string Telefono { get;  set; }


        [Required]
        public string Correo { get;  set; }



        [Required]
        public string Direccion { get;  set; }




    }
}
