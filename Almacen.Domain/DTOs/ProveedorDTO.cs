using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.DTOs
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
    }
}
