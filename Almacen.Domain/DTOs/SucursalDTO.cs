using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.DTOs
{
    public class SucursalDTO
    {

        public SucursalDTO(int id_sucursal, string nombre_sucursal, string telefono, string correo, string direccion)
        {
            Id_Sucursal = id_sucursal;
            Nombre_Sucursal = nombre_sucursal;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }
        public int Id_Sucursal { get; private set; }


      
        public string Nombre_Sucursal { get; private set; }

    
        public string Telefono { get; private set; }

     
        public string Correo { get; private set; }


 
        public string Direccion { get; private set; }

    }
}
