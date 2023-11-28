using Almacen.Domain.DTOs;
using Almacen.Domain.DTOs.SucursalDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.Entities
{
    public class Sucursal : Entity
    {
        private Sucursal()
        {

        }

        public Sucursal(string nombre_sucursal, string telefono, string correo, string direccion)
        {
            Nombre_Sucursal = nombre_sucursal;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }

        [Key]
        public int Id_Sucursal { get; private set; }


        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Nombre_Sucursal { get; private set; }

        [Phone]
        public string Telefono { get; private set; }

        [EmailAddress]
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Correo { get; private set; }


        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Direccion { get; private set; }





        public void Update(string nombre_sucursal, string telefono, string correo, string direccion)
        {
            Nombre_Sucursal = nombre_sucursal;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }



        public SucursalDTO AsDTO()
        {
            return AsDTO(this);
        }


        public static SucursalDTO AsDTO(Sucursal sucursal)
        {
            return new SucursalDTO(sucursal.Id_Sucursal, sucursal.Nombre_Sucursal, sucursal.Telefono, sucursal.Correo, sucursal.Direccion
               );
        }
    }
}
