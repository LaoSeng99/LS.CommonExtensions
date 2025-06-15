using System;

namespace LS.CommonExtensions.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Check if an integer is a prime number.
        /// </summary>
        /// <example>
        /// 7.IsPrime() // true
        /// 10.IsPrime() // false
        /// </example>
        /// <returns>true if the number is a prime; otherwise false.</returns>
        public static bool IsPrime(this int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Convert a byte size in bytes into a human-readable format (B, KB, MB, GB).
        /// </summary>
        /// <example>
        /// 1024.ToFileSizeString() // "1.00 KB"
        /// 1048576.ToFileSizeString() // "1.00 MB"
        /// </example>
        /// <returns>A human-readable size string.</returns>
        public static string ToFileSizeString(this int bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB" };
            int i = 0;
            double size = bytes;

            while (size >= 1024 && i < suffix.Length - 1)
            {
                size /= 1024;
                i++;
            }
            return $"{size:N2} {suffix[i]}";
        }

        /// <summary>
        /// Determine whether the number is odd.
        /// </summary>
        /// <example>
        /// 5.IsOdd() // true
        /// 6.IsOdd() // false
        /// </example>
        /// <returns>true if odd; false otherwise.</returns>
        public static bool IsOdd(this int number) => number % 2 != 0;

        /// <summary>
        /// Determine whether the number is even.
        /// </summary>
        /// <example>
        /// 4.IsEven() // true
        /// 7.IsEven() // false
        /// </example>
        /// <returns>true if even; false otherwise.</returns>
        public static bool IsEven(this int number) => number % 2 == 0;

        /// <summary>
        /// Clamp a number to a specified range.
        /// </summary>
        /// <example>
        /// 5.Clamp(10, 20) // 10
        /// 15.Clamp(10, 20) // 15
        /// 25.Clamp(10, 20) // 20
        /// </example>
        /// <returns>The clamped number.</returns>
        public static int Clamp(this int number, int min, int max)
        {
            if (number < min) return min;
            if (number > max) return max;
            return number;
        }
    }

}
