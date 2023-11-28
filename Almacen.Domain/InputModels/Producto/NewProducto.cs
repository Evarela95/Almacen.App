using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Producto
{
    public class NewProducto
    {
        public NewProducto()
        {
            
        }


        public string Nombre_Producto { get;  set; }

  
        public string Descripcion { get;  set; }

        public decimal Precio_Compra { get;  set; }

        public decimal Precio_Venta { get;  set; }


        // FKs

        public int Id_Categoria { get;  set; }



        public int Id_Proveedor { get;  set; }


        public int Id_Marca { get;  set; }

    }
}
