using Almacen.Application.Contracts.Identity;
using Almacen.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Almacen.Infrastructure.Authorization
{
    public class PolicyHandler : AuthorizationHandler<PolicyRequirement>, IAuthorizationHandler
    {
        private readonly IUserService _userService;

        public PolicyHandler(IUserService userService)
        {
            this._userService = userService;
        }

        protected override Task HandleRequirementAsync
            (AuthorizationHandlerContext context, PolicyRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
            }
            else
            {
                var hasAccess = false;
                var email = context.User.Identity.GetClaim(ClaimTypes.Email);

                foreach (var permission in requirement.Permissions)
                {
                    hasAccess = hasAccess ||
                        _userService.HasAccess(email,
                            permission.Controller, permission.Action).Success;

                    if (hasAccess)
                    {
                        context.Succeed(requirement);
                        break;
                    }
                }

                if (!hasAccess)
                {
                    context.Fail();
                }
            }

            return Task.CompletedTask;
        }
    }
}