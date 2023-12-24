using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersianAssistant.Extensions
{
    public static class OtherExtensions
    {
        public static string KafYePersian(this string input)
        {
            return input.Replace("ي", "ی").Replace("ك", "ک");
        }
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var adr = new System.Net.Mail.MailAddress(email);
                return adr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static string ToPath(this string url)
        {
            url = url.Replace("https://", "").Replace("www.", "").Replace("https://www.", "").Replace("//", "/");
            var split = url.Split('/').ToList();
            split.RemoveAt(0);
            var res = "/" + string.Join("/", split);
            return res;
        }
    }
}
