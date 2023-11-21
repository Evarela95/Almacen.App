using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Application.Diagnostics
{
    public class Guard
    {
        public struct Against
        {
            public static void ThrowIfNull(object value, string argumentName = null)
            {
                if (value == null)
                {
                    throw new ArgumentNullException
                        (string.IsNullOrEmpty(argumentName) ? nameof(value) : argumentName);
                }
            }

            public static void ThrowIfNullOrEmptyOrWhiteSpace(string value, string argumentName)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(argumentName);
                }
            }
        }

        public struct Ensure
        {
            public static bool IsGreatherThan(int value, int floor)
            {
                return value > floor;
            }

            public static bool IsLessThan(int value, int ceiling)
            {
                return value < ceiling;
            }

            public static bool IsBetween(int value, int floor, int ceiling)
            {
                return value >= floor && value <= ceiling;
            }

            public static bool IsNullOrEmptyOrWhiteSpace(string value)
            {
                return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
            }

            public static bool IsNotNullOrEmptyOrWhiteSpace(string value)
            {
                return !IsNullOrEmptyOrWhiteSpace(value);
            }
        }
    }
}
