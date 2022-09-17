using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges_examples.LanguageExtensions
{
    public static class GenericExtensions
    {
        public static List<T> GetRange<T>(this List<T> list, Range range)
        {
            var (start, length) = range.GetOffsetAndLength(list.Count);
            return list.GetRange(start, length);
        }

        /// <summary>
        /// Determine if value is negative
        /// </summary>
        /// <typeparam name="T">Type implementing IComparable</typeparam>
        /// <param name="value">Value to test</param>
        /// <returns>true if negative, false otherwise</returns>
        public static bool IsNegative<T>(this T value) where T : struct, IComparable<T> =>
            value.CompareTo(default(T)) == -1;

        /// <summary>
        /// Determine if value is positive
        /// </summary>
        /// <typeparam name="T">Type implementing IComparable</typeparam>
        /// <param name="value">Value to test</param>
        /// <returns>true if positive, false otherwise</returns>
        public static bool IsPositive<T>(this T value) where T : struct, IComparable<T> => value.CompareTo(default(T)) > 0;


    }
}
