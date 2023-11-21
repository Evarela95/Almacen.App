﻿using Almacen.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.Entities
{
    public class Categoria : Entity
    {
        private Categoria()
        {
            
        }

        public Categoria (string categoria)
        {
            categoria = Nombre_Categoria;
        }


        [Key]
        public int Id_Categoria { get; private set; }

        [MaxLength(30)]
        [MinLength(3)]
        [Display(Name = "Nombre de categoría")]
        [Required]
        public string Nombre_Categoria { get; private set; }
        

        public void Update(string categoria)
        {
            categoria = Nombre_Categoria;
        }


        public CategoriaDTO AsDTO()
        {
            return AsDTO(this);
        }


        public static CategoriaDTO AsDTO(Categoria categoria)
        {
            return new CategoriaDTO(categoria.Id_Categoria, categoria.Nombre_Categoria);
        }

      
    }
}
