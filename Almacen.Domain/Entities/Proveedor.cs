using Almacen.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.Entities
{
    public class Proveedor : Entity
    {
        private Proveedor() {  }

        public Proveedor(string nombre_proveedor, string telefono, string correo)
        {
            Nombre_Proveedor = nombre_proveedor;
            Telefono = telefono;
            Correo = correo;
        }

        [Key]
        public int Id_Proveedor { get; private set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Nombre_Proveedor { get; private set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        [Phone]
        public string Telefono{ get; private set; }

        [EmailAddress]
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Correo {  get; private set; }

        public void Update(string nombre_proveedor, string telefono, string correo)
        {
            Nombre_Proveedor = nombre_proveedor;
            Telefono = telefono;
            Correo = correo;
        }



        public ProveedorDTO AsDTO()
        {
            return AsDTO(this);
        }


        public static ProveedorDTO AsDTO(Proveedor proveedor)
        {
            return new ProveedorDTO(proveedor.Id_Proveedor, proveedor.Nombre_Proveedor, proveedor.Correo, proveedor.Telefono);
        }
    }
}
