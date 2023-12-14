using Almacen.Application.Diagnostics;
using Almacen.Domain.InputModels;

namespace Almacen.Application.Components
{
    public class Result
    {
        protected Result(bool success, string error)
        {
            if (success && Guard.Ensure.IsNotNullOrEmptyOrWhiteSpace(error))
            {
                throw new InvalidOperationException("Success operations should not be befriended by error messages.");
            }

            if (!success && Guard.Ensure.IsNullOrEmptyOrWhiteSpace(error))
            {
                throw new InvalidOperationException("Unsucessfull operations should be befriended by error messages.");
            }

            Success = success;
            Error = error;
        }

        public bool Success { get; }

        public bool Failure => !Success;

        public string Error { get; }

        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        public static Result Fail(string errorMessage)
        {
            return new Result(false, errorMessage);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(true, string.Empty, value);
        }

        public static Result<T> Fail<T>(string errorMessage)
        {
            return new Result<T>(false, errorMessage, default(T));
        }
    }

    public class Result<T> : Result
    {
        protected internal Result(bool success, string error, T value)
            : base(success, error)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
