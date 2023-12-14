using Almacen.Application.Features.Users.Commands;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Almacen.Tests
{
    public class AddNewUserCommandValidatorTests
    {
        private readonly AddNewUserCommandValidator _validator;

        public AddNewUserCommandValidatorTests()
        {
            _validator = new AddNewUserCommandValidator();
        }

        [Xunit.Theory]
        // Empty email
        [InlineData("", "password", "password", false)]
        // Empty password
        [InlineData("test@example.com", "", "password", false)]
        // Passwords don't match
        [InlineData("test@example.com", "password", "differentPassword", false)]
        // Password length less than 6 characters
        [InlineData("test@example.com", "pass", "pass", false)]
        // Password length more than 20 characters
        [InlineData("test@example.com", "verylongpasswordthatexceeds20characters", "verylongpasswordthatexceeds20characters", false)]
        // Valid data
        [InlineData("test@example.com", "password", "password", true)] 
        public void Validate_NewUser_ReturnsExpected(string email, string password, string confirmPassword, bool expected)
        {
            // Arrange 
            var newUser = new AddNewUserCommand(email, password, confirmPassword);

            // Act
            var result = _validator.TestValidate(newUser);

            // Assert
            Assert.That(result.IsValid, Is.EqualTo(expected));
        }       
    }
}
