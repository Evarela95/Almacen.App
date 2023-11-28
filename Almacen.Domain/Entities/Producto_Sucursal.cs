using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.Producto_SucursalDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.Entities
{
    public class Producto_Sucursal : Entity
    {
        private Producto_Sucursal() { }

        public Producto_Sucursal( int cantidad, int id_sucursal,  int id_producto)
        {
     
            Cantidad = cantidad;
            Id_Sucursal = id_sucursal;
            Id_Producto = id_producto;
        }

        [Key]
        public int Id { get; private set; }

        [Range(0, 10000000)]
        [Required]
        public int Cantidad { get; private set; }


        //FKs
        [ForeignKey("Sucursal")]
        public int Id_Sucursal { get; private set; }
        public Sucursal Sucursal { get; private set; }

        [ForeignKey("Producto")]
        public int Id_Producto { get; private set; }
        public Producto Producto { get; private set; }



        public void Update(int cantidad, int id_sucursal, int id_producto)
        {

            Cantidad = cantidad;
            Id_Sucursal = id_sucursal;
            Id_Producto = id_producto;
        }






        public Producto_SucursalDTO AsDTO()
        {
            return AsDTO(this);
        }


        public static Producto_SucursalDTO AsDTO(Producto_Sucursal producto_sucursal)
        {
            return new Producto_SucursalDTO(producto_sucursal.Id, producto_sucursal.Cantidad,
                producto_sucursal.Id_Sucursal, producto_sucursal.Id_Producto);
        }
    }
}
