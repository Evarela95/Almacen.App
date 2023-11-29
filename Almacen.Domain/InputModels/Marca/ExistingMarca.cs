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


        public int Id_Marca { get;  set; }

        public string Nombre_Marca { get;  set; }



        public static implicit operator ExistingMarca(DTOs.MarcaDTO.MarcaDTO marca)
        {
            return new ExistingMarca
            {
                Id_Marca = marca.Id_Marca,
                Nombre_Marca = marca.Nombre_Marca
            };
        }
    }
}
