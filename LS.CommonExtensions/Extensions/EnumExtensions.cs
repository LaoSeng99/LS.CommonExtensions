using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LS.CommonExtensions.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            if (enumValue == null)
                throw new ArgumentNullException(nameof(enumValue), "Enum cannot be null.");

            var attribute = enumValue.GetType()
                                       .GetField(enumValue.ToString())?
                                       .GetCustomAttribute<DisplayAttribute>();

            return attribute?.Name ?? enumValue.ToString().SplitCamelCase();
        }

        public static int GetIntValue(this Enum enumValue)
        {
            if (enumValue == null)
                throw new ArgumentNullException(nameof(enumValue), "Enum cannot be null.");

            return Convert.ToInt32(enumValue);
        }

        public static string GetDisplayNameAndNumber(this Enum enumValue)
        {
            if (enumValue == null)
                throw new ArgumentNullException(nameof(enumValue), "Enum cannot be null.");

            return $"{GetIntValue(enumValue)} ({GetDisplayName(enumValue)})";
        }
    }
}
