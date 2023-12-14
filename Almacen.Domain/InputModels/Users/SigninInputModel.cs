using Almacen.Domain.Atributtes;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Almacen.Domain.InputModels.Users
{
    public class SigninInputModel
    {
        [Required]
        [EmailAddress]
        [StringLength(150, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [NotRequired]
        public string? ReturnUrl { get; set; }

        [NotRequired]
        public IEnumerable<AuthenticationScheme>? ExternalSignins { get; set; }
    }
}
