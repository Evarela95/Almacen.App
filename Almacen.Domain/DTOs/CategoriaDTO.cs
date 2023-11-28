using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.DTOs.CategoriaDTO
{
    public class CategoriaDTO
    {
        public CategoriaDTO(int id_categoria, string nombre_categoria)
        {
            Id_Categoria = id_categoria;
            Nombre_Categoria = nombre_categoria;
        }

        public int Id_Categoria { get; private set; }

       
        public string Nombre_Categoria { get; private set; }
      
    }
}
