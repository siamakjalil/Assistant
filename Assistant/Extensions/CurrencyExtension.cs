using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Extensions
{
    public static class CurrencyExtension
    {
        public static string Rial(this decimal value)
        {
            return value.ToString("#,0 ریال");
        }

        public static string Rial(this double value)
        {
            return value.ToString("#,0 ریال");
        }

        public static string Rial(this int value)
        {
            return value.ToString("#,0 ریال");
        }
        public static string Toman(this float value)
        {
            return value.ToString("#,0 تومان");
        }
        public static string Toman(this int? value)
        {
            return value == null ? 0.ToString("#,0 تومان") : value.Value.ToString("#,0 تومان");
        }
        public static string Toman(this double? value)
        {
            return value == null ? 0.ToString("#,0 تومان") : value.Value.ToString("#,0 تومان");
        }
    }
}
