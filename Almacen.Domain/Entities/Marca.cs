using Almacen.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.Entities
{
    public class Marca : Entity
    {
        private Marca()
        {

        }

        public Marca( string marca)
        {

            marca = Nombre_Marca;
        }


        [Key]
        public int Id_Marca { get; private set; }


        [MaxLength(30)]
        [MinLength(3)]
        [Display(Name = "Nombre de marca")]
        [Required]
        public string Nombre_Marca { get; private set; }


        public void Update(string marca)
        {
            marca = Nombre_Marca;
        }


        public MarcaDTO AsDTO()
        {
            return AsDTO(this);
        }


        public static MarcaDTO AsDTO(Marca marca)
        {
            return new MarcaDTO(marca.Id_Marca, marca.Nombre_Marca);
        }
    }
}
