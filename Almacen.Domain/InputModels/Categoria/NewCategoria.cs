using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Categoria
{
    public class NewCategoria
    {
        public NewCategoria()
        {
            
        }

        public string Nombre_Categoria { get; set; }
    }
}
