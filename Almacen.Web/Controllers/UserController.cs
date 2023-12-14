using Almacen.Application.Contracts.Identity;
using Almacen.Application.Diagnostics;
using Almacen.Application.Features.Users.Commands;
using Almacen.Domain.InputModels.Users;
using Almacen.Infrastructure.Services;
using DNTCaptcha.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Web.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly EmailService _emailService;
        private readonly IDNTCaptchaValidatorService _validatorService;

        public UserController(IDNTCaptchaValidatorService validatorService, EmailService emailService, IUserService userService, IMediator mediator, UserManager<IdentityUser> userManager)
        {
            this._userService = userService;
            this._mediator = mediator;
            this._userManager = userManager;
            _emailService = emailService;
            _validatorService = validatorService;
        }

        [HttpGet]
        public async Task<IActionResult> Signin()
        {
            var model = new SigninInputModel
            { ExternalSignins = await _userService.GetExternalSignins() };
            return View(model);
        }

        [HttpPost]
        [ValidateDNTCaptcha(
            ErrorMessage = "Please Enter Valid Captcha")]
        public async Task<IActionResult> Signin(SigninInputModel model)
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

            model.ExternalSignins = await _userService.GetExternalSignins();
            return View(model);
        }

        [HttpGet]
        public IActionResult Signup()
        {
            var model = new SignupInputModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupInputModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send
                    (new AddNewUserCommand(model.Email, model.Password, model.ConfirmPassword));

                if (result.Success)
                {
                    return RedirectToAction(nameof(Signin));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

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
            returnUrl = Guard.Ensure.OnNullOrEmptyOrWhiteSpace(returnUrl, "~/");

            var model = new SigninInputModel
            {
                ExternalSignins = await _userService.GetExternalSignins(),
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
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var result = await _userService.Logout();

            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["ErrorMessage"] = "Logout failed";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult PasswordResetConfirmation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                ModelState.AddModelError(string.Empty, "El usuario no existe o el correo electrónico no está confirmado.");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "User", new { email = user.Email, token }, Request.Scheme);


            var emailSubject = "Restablecer Contraseña";
            var emailBody = $"Para restablecer tu contraseña, haz clic <a href='{callbackUrl}'>aquí</a>.";
            try
            {
                await _emailService.SendEmailAsync(email, emailSubject, emailBody);
                return RedirectToAction("PasswordResetConfirmation");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error al enviar el correo electrónico: {ex.Message}");
                return View();
            }
        }
        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            var model = new ResetPasswordInputModel { Email = email, Token = token };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordInputModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {

                    return RedirectToAction("Error");
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {

                    return RedirectToAction("Signin", "User");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
