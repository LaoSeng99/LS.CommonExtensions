using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LS.CommonExtensions.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Format decimal as currency with a specified CultureInfo.
        /// </summary>
        /// <example>
        /// 1234.5m.ToCurrencyString(new CultureInfo("en-US")) // "$1,234.50"
        /// 1234.5m.ToCurrencyString(new CultureInfo("ms-MY")) // "RM1,234.50"
        /// 1234.5m.ToCurrencyString(new CultureInfo("de-DE")) // "1.234,50 €"
        /// </example>
        /// <returns>A currency-formatted string for the specified culture.</returns>
        public static string ToCurrencyString(this decimal amount, CultureInfo culture)
        {
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            return string.Format(culture, "{0:C}", amount);
        }

    }
}
