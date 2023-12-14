using NUnit.Framework;
using Almacen.Application.Components;

namespace Guests.Tests.Application
{
    public class ResultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create_OkResult_ReturnsSuccess()
        {
            // Arrange
            var result = Result.Ok();

            // Act

            // Assert
            Assert.That(result.Success, Is.EqualTo(true));
        }

        [Test]
        public void Create_FailResult_ReturnsError()
        {
            const string NULL_OR_EMPTY_ERROR = "Value cannot be null or empty.";

            // Arrange
            var result = Result.Fail(NULL_OR_EMPTY_ERROR);

            // Act

            // Assert
            Assert.That(result.Success, Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(NULL_OR_EMPTY_ERROR));
        }
    }
}