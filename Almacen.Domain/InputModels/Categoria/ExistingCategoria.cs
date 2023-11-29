using Almacen.Domain.InputModels.Sucursal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Categoria
{
    public class ExistingCategoria
    {

        public ExistingCategoria()
        {
            
        }



        public int Id_Categoria { get;  set; }

     
        public string Nombre_Categoria { get;  set; }



        public static implicit operator ExistingCategoria(DTOs.CategoriaDTO.CategoriaDTO categoriaDTO)
        {
            return new ExistingCategoria
            {
                Id_Categoria = categoriaDTO.Id_Categoria,
                Nombre_Categoria = categoriaDTO.Nombre_Categoria


            };
        }
    }
}
