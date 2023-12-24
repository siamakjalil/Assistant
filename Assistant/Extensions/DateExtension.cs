using PersianAssistant.Models; 
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PersianAssistant.Extensions
{
    public static class DateExtension
    {
        /// <summary>
        /// Convert date to persian date without time
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPersianDate(this DateTime value)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                return $"{pc.GetYear(value)}/{pc.GetMonth(value):00}/{pc.GetDayOfMonth(value):00}";
            }
            catch (Exception e)
            {
                return "";
            }
        }

        /// <summary>
        /// Convert date to persian date with time
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPersianDateTime(this DateTime value)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();

                return $"{pc.GetYear(value)}/{pc.GetMonth(value):00}/{pc.GetDayOfMonth(value):00} " +
                       $"{value.Hour:00}:{value.Minute:00}:{value.Second:00}";
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public static string DayOfWeekPersianTitle(this DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Saturday => "شنبه",
                DayOfWeek.Sunday => "یکشنبه",
                DayOfWeek.Monday => "دوشنبه",
                DayOfWeek.Tuesday => "سه شنبه",
                DayOfWeek.Wednesday => "چهارشنبه",
                DayOfWeek.Thursday => "پنجشنبه",
                DayOfWeek.Friday => "جمعه",
                _ => ""
            };
        }

        public static int DayOfWeekPersianIndex(this DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Saturday => 1,
                DayOfWeek.Sunday => 2,
                DayOfWeek.Monday => 3,
                DayOfWeek.Tuesday => 4,
                DayOfWeek.Wednesday => 5,
                DayOfWeek.Thursday => 6,
                DayOfWeek.Friday => 7,
                _ => 0
            };
        }
        public static string PersianDayTitleByIndex(this int index)
        {
            return index switch
            {
                1 => "شنبه",
                2 => "یکشنبه",
                3 => "دوشنبه",
                4 => "سه شنبه",
                5 => "چهارشنبه",
                6 => "پنجشنبه",
                7 => "جمعه",
                _ => ""
            };
        }

        public static List<DropDownModels> PersianDaysDropDown()
        {
            var list = new List<DropDownModels>();
            for (int i = 1; i <= 7; i++)
            {
                list.Add(new DropDownModels()
                {
                    Id = i,
                    Title = i.PersianDayTitleByIndex()
                });
            }
            return list;
        }
        public static bool IsPersianDayValidInMonth(int month, int day)
        {
            if (day != 31) return true;
            return month <= 6;
        }

        public static string PersianMonthTitleByIndex(this int month)
        {
            return month switch
            {
                1 => "فروردین",
                2 => "اردیبهشت",
                3 => "خرداد",
                4 => "تیر",
                5 => "مرداد",
                6 => "شهریور",
                7 => "مهر",
                8 => "آبان",
                9 => "آذر",
                10 => "دی",
                11 => "بهمن",
                12 => "اسفند",
                _ => ""
            };
        }
        /// <summary>
        /// Convert persian date to date without time
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static DateTime? PersianDateToDate(this string dateStr)
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                var dateArray = dateStr.Split('/');
                var year = int.Parse(dateArray[0].ToEnglishNumber());
                var month = int.Parse(dateArray[1].ToEnglishNumber());
                var day = int.Parse(dateArray[2].ToEnglishNumber());
                var dt = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        /// <summary>
        /// Convert persian date to date with time
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>

        public static DateTime? PersianDateToDateTime(this string dateStr)
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                var array = dateStr.Split(' ');
                var strDate = array[0].Split('/');
                var time = array[1].Split(':');
                var year = int.Parse(strDate[0].ToEnglishNumber());
                var month = int.Parse(strDate[1].ToEnglishNumber());
                var day = int.Parse(strDate[2].ToEnglishNumber());
                var h = int.Parse(time[0].ToEnglishNumber());
                var m = int.Parse(time[1].ToEnglishNumber());
                var s = int.Parse(time[2].ToEnglishNumber());
                var dt = persianCalendar.ToDateTime(year, month, day, h, m, s, 0);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Return start date as res[0] and end date as res[1] from params date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static List<DateTime> StartAndEndOfMonth(this DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            return new List<DateTime>() { startDate, endDate };
        }
        /// <summary>
        /// Return start date as res[0] and end date as res[1] from params date in persian 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static List<string> BeginEndOfMonthAsPersian(this DateTime dateTime)
        {
            var year = dateTime.GetPersianYear();
            var month = dateTime.GetPersianMonth();
            var day = month <= 6 ? 31 : 30;
            return new List<string>()
            {
                $"{year}/{month}/{01}",
                $"{year}/{month}/{day}"
            };
        }


        public static int GetPersianYear(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value);
        }
        public static int GetPersianDay(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetDayOfMonth(value);
        }
        public static int GetPersianMonth(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetMonth(value);
        }
        public static List<string> GetYearList(int from, int to)
        {
            PersianCalendar pc = new PersianCalendar();
            var years = new List<string>();
            var date = DateTime.Now;
            for (int i = from; i < to; i++)
            {
                years.Add(pc.GetYear(date.AddYears(-i)).ToString());
            }

            return years;
        }
        public static List<DropDownModels> GetMonthList()
        {
            var month = new List<DropDownModels>();
            for (int i = 1; i <= 12; i++)
            {
                month.Add(new DropDownModels()
                {
                    Id = i,
                    Title = i.PersianMonthTitleByIndex()
                });
            }

            return month;
        }
        public static List<int> GetDayList()
        {
            var day = new List<int>();
            for (int i = 1; i <= 31; i++)
            {
                day.Add(i);
            }

            return day;
        }
        public static string GetDateInfo(DateTime? enterDate)
        {
            var date = enterDate ?? DateTime.Now;
            var year = date.GetPersianYear();
            var month = date.GetPersianMonth();
            var day = date.GetPersianDay();
            var dayVal = date.DayOfWeek.DayOfWeekPersianTitle();
            var monthVal = month.PersianMonthTitleByIndex();
            return dayVal + " " + day.ToString().ToPersianNumber() + " " + monthVal + " " + year.ToString().ToPersianNumber();

        }

        public static bool DayDifference(this string date, int difference)
        {
            if (string.IsNullOrEmpty(date))
            {
                return false;
            }

            var now = DateTime.Now.ToPersianDate().Split('/');
            var startDate = date.Split('/');
            int ignoreMe = 0;
            bool successfullyParsed = int.TryParse(startDate[2], out ignoreMe);
            if (!successfullyParsed)
            {
                var temp = date.PersianDateToDate();
                date = temp != null ? temp.Value.ToPersianDate() : DateTime.Now.ToPersianDate();
                startDate = date.Split('/');
            }
            var year = int.Parse(now[0]) - int.Parse(startDate[0]);
            var dOfy = year * 365;
            var nMonth = int.Parse(now[1]) <= 6 ? int.Parse(now[1]) * 31 : int.Parse(now[1]) * 30;
            var sMonth = int.Parse(startDate[1]) <= 6 ? int.Parse(startDate[1]) * 31 : int.Parse(startDate[1]) * 30;
            var month = nMonth - sMonth;
            var day = int.Parse(now[2]) - int.Parse(startDate[2]);
            var value = dOfy + month + day;
            return (value > 31 || value > 30);
        }

        public static string NotificationDateTimeStringFormat(this DateTime dateTime)
        {
            var date = dateTime.Date.Year;
            var month = dateTime.Date.Month;
            var day = dateTime.Date.Day;
            var time = dateTime.TimeOfDay;
            var model = date + "-" + month + "-" + day + " " + time + " " + "GMT+0330";
            return model;
        }

    }
}
