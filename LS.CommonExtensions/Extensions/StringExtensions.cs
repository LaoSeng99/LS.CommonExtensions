using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LS.CommonExtensions.Extensions
{

    public static class StringExtensions
    {
        /// <summary>
        /// Transform a string to Title Case (capitalizing first letters of words).
        /// </summary>
        /// <example>
        /// "hello world".ToTitleCase() // "Hello World"
        /// </example>
        public static string ToTitleCase(this string str, CultureInfo culture = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            culture ??= CultureInfo.CurrentCulture;
            return culture.TextInfo.ToTitleCase(str.ToLower());
        }

        /// <summary>
        /// Split PascalCase or camelCase into separate words.
        /// </summary>
        /// <example>
        /// "ProductCode".SplitCamelCase() // "Product Code"
        /// </example>
        public static string SplitCamelCase(this string input)
        {
            return Regex.Replace(input, "(\\B[A-Z])", " $1");
        }

        /// <summary>
        /// Remove all whitespace from a string.
        /// </summary>
        /// <example>
        /// "foo bar ".RemoveWhiteSpace() // "foobar"
        /// </example>
        public static string RemoveWhiteSpace(this string str)
        {
            return Regex.Replace(str, @"\s+", "");
        }

        /// <summary>
        /// Transform a string into a SEO-friendly "slug".
        /// </summary>
        /// <example>
        /// "My Product Title!".ToSlug() // "my-product-title"
        /// </example>
        public static string ToSlug(this string str)
        {
            return Regex.Replace(str?.ToLowerInvariant() ?? string.Empty, @"[^a-z0-9]+", "-", RegexOptions.Compiled).Trim('-');
        }

        /// <summary>
        /// Masks a string except for a specified number of start and end visible chars safely.
        /// If visibleStart + visibleEnd > str.Length, it will return the original string.
        /// </summary>
        /// <example>
        /// "1234567890".MaskSensitive(3, 4) // "123***7890"
        /// "12345".MaskSensitive(3, 4) // "12345" (since visibleStart + visibleEnd > length)
        /// </example>
        public static string MaskSensitive(this string str, int visibleStart = 3, int visibleEnd = 4, char mask = '*')
        {
            if (string.IsNullOrEmpty(str)) return str;

            if (visibleStart + visibleEnd >= str.Length)
            {
                // If visible segments are greater or equal to the length, we leave it as is
                return str;
            }
            return str.Substring(0, visibleStart) + new string(mask, str.Length - visibleStart - visibleEnd) + str.Substring(str.Length - visibleEnd);
        }


        /// <summary>
        /// Performs a case-insensitive search for a specified term in a string.
        /// </summary>
        /// <example>
        /// "Hello World".ContainsIgnoreCase("hello") // true
        /// </example>
        public static bool ContainsIgnoreCase(this string str, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(str) ||
                string.IsNullOrWhiteSpace(searchTerm))
                return false;

            return str.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
