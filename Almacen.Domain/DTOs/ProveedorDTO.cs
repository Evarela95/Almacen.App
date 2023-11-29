using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.DTOs.ProveedorDTO
{
    public class ProveedorDTO
    {
        public ProveedorDTO(int id_proveedor, string nombre_proveedor, string telefono, string correo)
        {
            Id_Proveedor = id_proveedor;
            Nombre_Proveedor = nombre_proveedor;
            Telefono = telefono;
            Correo = correo;
        }

        public int Id_Proveedor { get; private set; }

        public string Nombre_Proveedor { get; private set; }

    
        public string Telefono { get; private set; }

        
        public string Correo { get; private set; }



        public bool HasChange { get; private set; }


        public void Update(string nombre_proveedor, string telefono, string correo)
        {
            HasChange =
             !nombre_proveedor.Equals(Nombre_Proveedor, StringComparison.OrdinalIgnoreCase) &&
             !telefono.Equals(Telefono, StringComparison.OrdinalIgnoreCase) &&
            !correo.Equals(Correo, StringComparison.OrdinalIgnoreCase);

            Nombre_Proveedor = nombre_proveedor;
            Telefono = telefono;
            Correo = correo;
          
        }
    }
}
