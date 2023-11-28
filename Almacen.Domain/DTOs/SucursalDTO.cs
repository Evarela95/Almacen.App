using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.DTOs.SucursalDTO
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

        public bool HasChange { get; private set; }


        public void Update(string nombre_sucursal, string telefono, string correo, string direccion)
        {
            HasChange =
             !nombre_sucursal.Equals(Nombre_Sucursal, StringComparison.OrdinalIgnoreCase) &&
             !telefono.Equals(Telefono, StringComparison.OrdinalIgnoreCase) &&
            !correo.Equals(Correo, StringComparison.OrdinalIgnoreCase) &&
            !direccion.Equals(Direccion, StringComparison.OrdinalIgnoreCase);

            Nombre_Sucursal = nombre_sucursal;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }

    }
}
