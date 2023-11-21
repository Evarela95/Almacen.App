using Almacen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.DTOs
{
    public class Producto_SucursalDTO
    {
        public Producto_SucursalDTO(int id, int cantidad, int id_sucursal, int id_producto)
        {
            Id = id;
            Cantidad = cantidad;
            Id_Sucursal = id_sucursal;
            Id_Producto = id_producto;
        }


        public int Id { get; private set; }

      
        public int Cantidad { get; private set; }


        
        public int Id_Sucursal { get; private set; }
        public Sucursal Sucursal { get; private set; }

       
        public int Id_Producto { get; private set; }
        public Producto Producto { get; private set; }

    }
}
