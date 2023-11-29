using Almacen.Aplication.Components;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<Result> Register(string email, string password);
        Task<Result> Signin(string email, string password);
        Task<Result> Logout();
        Task<IEnumerable<AuthenticationScheme>> GetExternalSignins();
        AuthenticationProperties ConfigureExternalSignin(string provider, string redirectUrl);
        Task<Result> ExternalSignin();
        Result HasAccess(string email, string controller, string action);

    }
}
