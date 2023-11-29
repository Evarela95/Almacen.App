using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Marca
{
    public class NewMarca
    {

        public NewMarca()
        {
            
        }



        [Required]
        public string Nombre_Marca { get;  set; }
    }


}
