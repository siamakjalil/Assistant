using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Extensions
{
    public static class TimeExtension
    {
        public static string ToTime(this double time)
        {

            return ((time < 10) ? "0" + time + ":" + "00" : time + ":" + "00");
        }
        public static string ToTime(this DateTime time)
        {

            return time.ToString("HH:mm"); ;
        }
        public static int[] ToIntTime(this DateTime time)
        {
            var convert = time.ToString("HH:mm").Split(':');
            return new int[]
            {
                int.Parse(convert[0]),
                int.Parse(convert[1]),
            };
        }
        public static bool TimeDifference(this DateTime dateTime, int difference)
        {
            var timeNow = DateTime.Now;
            var res = timeNow.Subtract(dateTime);
            var d = res.Days * 24 * 60;
            var h = res.Hours * 60;
            var m = res.Minutes;
            var sum = d + h + m;
            return sum < difference;
        }
    }
}
