using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Producto_Sucursal
{
    public class ExistingProducto_Sucursal
    {
        public ExistingProducto_Sucursal()
        {
            
        }



        public int Id { get; private set; }

        public int Cantidad { get; private set; }


        //FKs
    
        public int Id_Sucursal { get; private set; }
    
        public int Id_Producto { get; private set; }


    }
}
