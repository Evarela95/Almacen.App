using Almacen.Aplication.Components;
using Almacen.Application.Contracts.Identity;
using Almacen.Application.Contracts.Repositories;
using Almacen.Application.Diagnostics;
using Almacen.Domain.EntityModels.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signingManager;
        private readonly IUserRepository _repository;

        public UserService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signingManager, IUserRepository repository)
        {
            this._userManager = userManager;
            this._signingManager = signingManager;
            this._repository = repository;
        }

        public async Task<Result> Register(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    builder.AppendLine(error.Description);
                }
                return Result.Fail(builder.ToString());
            }
            _repository.Insert(new SystemUser(email));
            return Result.Ok();
        }

        public async Task<Result> Signin(string email, string password)
        {
            var result = await _signingManager.PasswordSignInAsync
                    (email, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Result.Fail("Invalid user and password combination");
            }

            return Result.Ok();
        }

        public async Task<Result> Logout()
        {
            await _signingManager.SignOutAsync();
            return Result.Ok();
        }

        public async Task<IEnumerable<AuthenticationScheme>> GetExternalSignins()
        {
            return await _signingManager.GetExternalAuthenticationSchemesAsync();
        }

        public AuthenticationProperties ConfigureExternalSignin(string provider, string redirectUrl)
        {
            return _signingManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

        public async Task<Result> ExternalSignin()
        {
            var info = await _signingManager.GetExternalLoginInfoAsync();
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            if (Guard.Ensure.IsNullOrEmptyOrWhiteSpace(email))
            {
                return Result.Fail("Invalid user and password combination.");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser { UserName = email, Email = email };
                await _userManager.CreateAsync(user);
            }

            var login = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (login == null)
            {
                await _userManager.AddLoginAsync(user, info);
            }

            var result = await _signingManager.ExternalLoginSignInAsync
                (info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (!result.Succeeded)
            {
                return Result.Fail("Invalid user and password combination.");
            }

            await _signingManager.SignInAsync(user, isPersistent: false);
            return Result.Ok();
        }

        public Result HasAccess(string email, string controller, string action)
        {
            var systemUser = _repository.Get(s => s.Email == email, i => i.Permissions);
            if (systemUser == null)
            {
                return Result.Fail("User not found.");
            }
            if (systemUser.Permissions.Any(s => s.Controller == controller && s.Action == action))
            {
                return Result.Fail("Access denied.");
            }
            return Result.Ok();
        }
    }
}