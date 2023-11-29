using Almacen.Application.Contracts.Identity;
using Almacen.Application.Diagnostics;
using Almacen.Domain.InputModels.Users;
using Almacen.Application.Contracts.Identity;
using Almacen.Application.Diagnostics;
using Almacen.Domain.InputModels.Users;
using Almacen.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Almacen.Web.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Signin()
        {
            var model = new LoginInputModel
            { ExternalLogins = await _userService.GetExternalSignins() };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Signin(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Signin(model.Email, model.Password);
                if (result.Success)
                {
                    return LocalRedirect("/home/index");
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

            model.ExternalLogins = await _userService.GetExternalSignins();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalSignin(string provider, string returnUrl)
        {
            var redirectUrl =
                Url.Action("ExternalSigninCallback", "User", new { ReturnUrl = returnUrl });
            var properties = _userService.ConfigureExternalSignin(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        [Route("signin-google")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> ExternalSigninCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = Guard.Ensure.ReplaceNullOrEmptyOrWhiteSpace(returnUrl, "~/");

            var model = new LoginInputModel
            {
                ExternalLogins = await _userService.GetExternalSignins(),
                ReturnUrl = returnUrl
            };

            if (Guard.Ensure.IsNotNullOrEmptyOrWhiteSpace(remoteError))
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View(nameof(Signin), model);
            }

            var result = await _userService.ExternalSignin();
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Error);
                return View(nameof(Signin), model);
            }

            return LocalRedirect(returnUrl);
        }
    }
}