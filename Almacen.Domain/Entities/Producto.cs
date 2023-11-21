using Almacen.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.Entities
{
    public class Producto : Entity
    {
        private Producto()
        {
            
        }

     
        public Producto(string nombre_producto, string descripcion, decimal precio_compra, decimal precio_venta,
            int id_categoria, int id_proveedor , int id_marca) 
        {
            Nombre_Producto = nombre_producto;
            Descripcion = descripcion;
            Precio_Compra = precio_compra;
            Precio_Venta = precio_venta;
            Id_Categoria = id_categoria;
            Id_Proveedor = id_proveedor;
            Id_Marca = id_marca;
        }


        [Key]
        public int Id_Producto { get; private set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Nombre_Producto { get; private set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Descripcion { get; private set; }

        [Required]
        [Display(Name = "Precio de compra")]
        [Range(0, 5000000.0)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio_Compra {  get; private set; }

        [Required]
        [Display(Name = "Precio de venta")]
        [Range(0, 5000000.0)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio_Venta { get; private set; }


        // FKs
        [ForeignKey("Categoria")]
        public int Id_Categoria { get; private set; }
        public Categoria Categoria { get; private set; }

        [ForeignKey("Proveedor")]
        public int Id_Proveedor { get; private set; }
        public Proveedor Proveedor { get; private set; }


        [ForeignKey("Marca")]
        public int Id_Marca { get; private set; }
        public Marca Marca { get; private set; }





        public void Update(string nombre_producto, string descripcion, decimal precio_compra, decimal precio_venta,
            int id_categoria, int id_proveedor, int id_marca)
        {
            Nombre_Producto = nombre_producto;
            Descripcion = descripcion;
            Precio_Compra = precio_compra;
            Precio_Venta = precio_venta;
            Id_Categoria = id_categoria;
            Id_Proveedor = id_proveedor;
            Id_Marca = id_marca;
        }



        public ProductoDTO AsDTO()
        {
            return AsDTO(this);
        }


        public static ProductoDTO AsDTO(Producto producto)
        {
            return new ProductoDTO(producto.Id_Producto, producto.Nombre_Producto, producto.Descripcion, producto.Precio_Compra,
                producto.Precio_Venta, producto.Id_Categoria, producto.Id_Marca, producto.Id_Proveedor);
        }
    }
}
