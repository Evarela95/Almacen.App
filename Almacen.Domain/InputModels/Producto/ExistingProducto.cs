using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Producto
{
    public class ExistingProducto
    {
        public ExistingProducto()
        {
            
        }


        public int Id_Producto { get; private set; }

        public string Nombre_Producto { get; private set; }

        public string Descripcion { get; private set; }

        public decimal Precio_Compra { get; private set; }


        public decimal Precio_Venta { get; private set; }


        // FKs
        public int Id_Categoria { get; private set; }

 
        public int Id_Proveedor { get; private set; }
     
        public int Id_Marca { get; private set; }
   
    }
}
