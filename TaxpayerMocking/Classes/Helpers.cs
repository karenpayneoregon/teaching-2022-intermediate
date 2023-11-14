using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaxpayerMocking.Models;

namespace TaxpayerMocking.Classes
{
    internal static class Helpers
    {
        public static bool IsValidSocialSecurityNumber(string value) =>
            Regex.IsMatch(value.Replace("-", ""),
                @"^(?!\b(\d)\1+\b)(?!123456789|219099999|078051120)(?!666|000|9\d{2})\d{3}(?!00)\d{2}(?!0{4})\d{4}$");

        public static List<ElementContainer<T>> RangeDetails<T>(this List<T> list) =>
            list.Select((element, index) => new ElementContainer<T>
            {
                Value = element,
                StartIndex = new Index(index),
                EndIndex = new Index(Enumerable.Range(0, list.Count).Reverse().ToList()[index], true),
                MonthIndex = index + 1
            }).ToList();
    }
}
