using Almacen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.DTOs.ProductoDTO
{
    public class ProductoDTO
    {
        public ProductoDTO(int id_producto, string nombre_producto, string descripcion, decimal precio_compra, decimal precio_venta,
            int id_categoria, int id_proveedor, int id_marca)
        {
            Id_Producto = id_producto;
            Nombre_Producto = nombre_producto;
            Descripcion = descripcion;
            Precio_Compra = precio_compra;
            Precio_Venta = precio_venta;
            Id_Categoria = id_categoria;
            Id_Proveedor = id_proveedor;
            Id_Marca = id_marca;
        }


        public int Id_Producto { get; private set; }


        public string Nombre_Producto { get; private set; }

        public string Descripcion { get; private set; }

        public decimal Precio_Compra { get; private set; }


        public decimal Precio_Venta { get; private set; }


        // FKs

        public int Id_Categoria { get; private set; }
        public Categoria Categoria { get; private set; }

        public int Id_Proveedor { get; private set; }
        public Proveedor Proveedor { get; private set; }

        public int Id_Marca { get; private set; }
        public Marca Marca { get; private set; }



        public bool HasChange { get; private set; }


        public void Update(string nombre_producto, string descripcion, decimal precio_compra, decimal precio_venta,
            int id_categoria, int id_proveedor, int id_marca)
        {
            HasChange =
             !nombre_producto.Equals(Nombre_Producto, StringComparison.OrdinalIgnoreCase) &&
             !descripcion.Equals(Descripcion, StringComparison.OrdinalIgnoreCase) &&
            !precio_compra.Equals(Precio_Compra) &&
            !precio_venta.Equals(Precio_Venta) &&
              !id_categoria.Equals(Id_Categoria) &&
                !id_proveedor.Equals(Id_Proveedor) &&
                   !id_marca.Equals(Id_Marca);


            Nombre_Producto = nombre_producto;
            Descripcion = descripcion;
            Precio_Compra = precio_compra;
            Precio_Venta = precio_venta;
            Id_Categoria = id_categoria;
            Id_Proveedor = id_proveedor;
            Id_Marca = id_marca;
        }
    }
}
