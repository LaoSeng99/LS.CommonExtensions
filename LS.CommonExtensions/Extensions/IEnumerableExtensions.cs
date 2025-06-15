using System;
using System.Collections.Generic;
using System.Text;

namespace LS.CommonExtensions.Extensions
{
    internal static class IEnumerableExtensions
    {
        internal static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }
    }
}
