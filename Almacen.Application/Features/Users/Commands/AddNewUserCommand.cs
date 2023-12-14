using FluentValidation;
using Almacen.Application.Components;
using Almacen.Application.Contracts.Identity;
using Almacen.Domain.EntityModels.Users;
using MediatR;

namespace Almacen.Application.Features.Users.Commands
{
    public sealed class AddNewUserCommandValidator
        : AbstractValidator<AddNewUserCommand>
    {
        public AddNewUserCommandValidator()
        {
            RuleFor(rule => rule.email)
                .NotNull().WithMessage("Email cannot be null.")
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Email is not a valid address.");

            RuleFor(rule => rule.password)
                .NotNull().WithMessage("Password cannot be null.")
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(6).WithMessage("Password minium length is 6 characters.")
                .MaximumLength(20).WithMessage("Password maximum length is 20 characters.");

            RuleFor(rule => rule.cofirmPassowrd)
                .NotNull().WithMessage("Confirm Password cannot be null.")
                .NotEmpty().WithMessage("Confirm Password cannot be empty.")
                .MinimumLength(6).WithMessage("Confirm Password minium length is 6 characters.")
                .MaximumLength(20).WithMessage("Confirm Password maximum length is 20 characters.")
                .Matches(rule => rule.password).WithMessage("Confirm Password and password do not match.");
        }
    }

    public sealed record AddNewUserCommand
        (string email, string password, string cofirmPassowrd)
            : IRequest<Result<SystemUser>>;

    public sealed class AddNewUserCommandHandler
        : IRequestHandler<AddNewUserCommand, Result<SystemUser>>
    {
        private readonly IUserService _userService;
        private readonly IValidator<AddNewUserCommand> _validator;

        public AddNewUserCommandHandler
            (IUserService userService, IValidator<AddNewUserCommand> validator)
        {
            this._userService = userService;
            this._validator = validator;
        }

        public async Task<Result<SystemUser>> Handle
            (AddNewUserCommand request, CancellationToken cancellationToken)
        {
            try
            { _validator.ValidateAndThrow(request); }
            catch (Exception ex) 
            { return Result.Fail<SystemUser>(ex.Message); }

            var result = await _userService.Register(request.email, request.password);
            if (result.Success)
            { 
                return Result.Ok(new SystemUser(request.email));
            }

            return Result.Fail<SystemUser>(UserErrors.NotCreated.Message);
        }
    }
}
