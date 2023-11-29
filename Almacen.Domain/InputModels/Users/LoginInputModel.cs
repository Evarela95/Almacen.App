using Almacen.Domain.Atributtes;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.InputModels.Users
{
    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        [StringLength(150, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [NotRequired]
        public string ReturnUrl { get; set; }
        [NotRequired]
        public IEnumerable<AuthenticationScheme> ExternalLogins { get; set; }
    }
}

