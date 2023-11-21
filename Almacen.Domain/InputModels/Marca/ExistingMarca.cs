using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Marca
{
    public class ExistingMarca
    {

        public ExistingMarca()
        {
            
        }


        public int Id_Marca { get; private set; }

        public string Nombre_Marca { get; private set; }
    }
}
