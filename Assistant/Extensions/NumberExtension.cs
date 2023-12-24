using PersianAssistant.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text; 

namespace PersianAssistant.Extensions
{
    public static class NumberExtension
    {
        public static string ToIranMobileNumber(this string mobileNumber)
        {
            mobileNumber = mobileNumber.Trim().ToEnglishNumber();
            if (mobileNumber.Length > 11)
            {
                var mobile = mobileNumber.Substring(mobileNumber.Length - 10);
                if (mobile.Substring(0, 1) != "9")
                {
                    return null;
                }
                return "0" + mobile;
            }

            if (mobileNumber.Length < 11)
            {
                return null;
            }

            if (mobileNumber.Substring(0, 1) != "0" || mobileNumber.Substring(1, 1) != "9")
            {
                return null;
            }

            return mobileNumber;


        }

        public static string ToEnglishNumber(this string number)
        {
            return number.Replace("۱", "1").Replace("۲", "2").Replace("۳", "3")
                .Replace("۴", "4").Replace("۵", "5").Replace("۶", "6")
                .Replace("۷", "7").Replace("۸", "8").Replace("۹", "9")
                .Replace("۰", "0").ToString();
        }
        public static string ToPersianNumber(this string number)
        {
            return number.Replace("1", "۱").Replace("2", "۲").Replace("3", "۳")
                .Replace("4", "۴").Replace("5", "۵").Replace("6", "۶")
                .Replace("7", "۷").Replace("8", "۸").Replace("9", "۹")
                .Replace("0", "۰").ToString();
        }
        public static string GenerateCode(this int val)
        {
            return
                Guid.NewGuid().GetHashCode().ToString().Replace("-", string.Empty).Substring(0, val);
        }
        public static bool CheckIranNationalCode(this string nationalCode)
        {
            long code;
            if (nationalCode == null) return false;
            if (nationalCode == "") return false;
            if (nationalCode.Length != 10) return false;
            if (!long.TryParse(nationalCode, out code)) return false;

            var allDigitEqual = new[]
            {
                "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666",
                "7777777777", "8888888888", "9999999999"
            };
            if (allDigitEqual.Contains(nationalCode)) return false;

            var num0 = int.Parse(nationalCode[0].ToString()) * 10;
            var num2 = int.Parse(nationalCode[1].ToString()) * 9;
            var num3 = int.Parse(nationalCode[2].ToString()) * 8;
            var num4 = int.Parse(nationalCode[3].ToString()) * 7;
            var num5 = int.Parse(nationalCode[4].ToString()) * 6;
            var num6 = int.Parse(nationalCode[5].ToString()) * 5;
            var num7 = int.Parse(nationalCode[6].ToString()) * 4;
            var num8 = int.Parse(nationalCode[7].ToString()) * 3;
            var num9 = int.Parse(nationalCode[8].ToString()) * 2;
            var a = int.Parse(nationalCode[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }
        public static bool IsDigitsOnly(this string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
        public static List<DropDownModels> NumberDropDown(int val)
        {
            var list = new List<DropDownModels>();
            for (int i = 1; i <= val; i++)
            {
                list.Add(new DropDownModels()
                {
                    Id = i,
                    Title = i.ToString()
                });
            }
            return list;
        }
        public static double Round1000(this double? val)
        {
            if (val == null || val == 0)
            {
                return 0;
            }

            double doubleVal;
            var strVal = Math.Round(val.Value).ToString();
            var last3 = strVal.Substring(strVal.Length - 3);
            if (last3 != "000")
            {
                var temp = strVal.Substring(0, strVal.Length - 3);
                doubleVal = Convert.ToDouble(temp) + 1;
                strVal = doubleVal.ToString(CultureInfo.InvariantCulture) + "000";
            }

            doubleVal = Convert.ToDouble(strVal);
            return doubleVal;
        }
    }
}
