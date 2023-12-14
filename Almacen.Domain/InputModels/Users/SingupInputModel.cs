using Almacen.Domain.Atributtes;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Almacen.Domain.InputModels.Users
{
    public class SignupInputModel
    {
        [Required]
        [EmailAddress]
        [StringLength(150, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
