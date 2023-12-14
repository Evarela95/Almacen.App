using System.ComponentModel.DataAnnotations;

namespace Almacen.Domain.Atributtes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
    public class NotRequired : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }

        public override bool IsValid(object? value)
        {
            return true;
        }
    }
}