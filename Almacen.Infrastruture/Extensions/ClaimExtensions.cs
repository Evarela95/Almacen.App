using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Infrastructure.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetClaim(this IIdentity claimsIdentity, string claimType)
        {
            return ((ClaimsIdentity)claimsIdentity).Claims.FirstOrDefault
                (s => s.Type == claimType)?.Value;
        }
    }
}
