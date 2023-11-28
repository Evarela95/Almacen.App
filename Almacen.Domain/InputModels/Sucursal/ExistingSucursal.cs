using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Sucursal
{
    public class ExistingSucursal
    {
        public ExistingSucursal()
        {

        }
        public int Id_Sucursal { get;  set; }


        public string Nombre_Sucursal { get;  set; }

        public string Telefono { get;  set; }

        public string Correo { get;  set; }


        public string Direccion { get;  set; }


        public static implicit operator ExistingSucursal(DTOs.SucursalDTO.SucursalDTO sucursalDTO)
        {
            return new ExistingSucursal
            {
                Id_Sucursal = sucursalDTO.Id_Sucursal,
                Nombre_Sucursal = sucursalDTO.Nombre_Sucursal,
                Telefono = sucursalDTO.Telefono,
                Correo = sucursalDTO.Correo,
                Direccion = sucursalDTO.Direccion


            };
        }
    }

}