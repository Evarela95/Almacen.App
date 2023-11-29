using Almacen.Domain.InputModels.Sucursal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Proveedor
{
    public class ExistingProveedor
    {
        public ExistingProveedor()
        {
            
        }


        public int Id_Proveedor { get;  set; }


        public string Nombre_Proveedor { get;  set; }

 
        public string Telefono { get;  set; }

        public string Correo { get;  set; }



        public static implicit operator ExistingProveedor(DTOs.ProveedorDTO.ProveedorDTO proveedorDTO)
        {
            return new ExistingProveedor
            {
                Id_Proveedor = proveedorDTO.Id_Proveedor,
                Nombre_Proveedor = proveedorDTO.Nombre_Proveedor,
                Telefono = proveedorDTO.Telefono,
                Correo = proveedorDTO.Correo


            };
        }


    }
}
