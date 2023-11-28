﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Producto_Sucursal
{
    public class NewProducto_Sucursal
    {
        public NewProducto_Sucursal()
        {
            
        }

    
        public int Cantidad { get;  set; }


        //FKs
  
        public int Id_Sucursal { get;  set; }

        public int Id_Producto { get;  set; }


    }
}
