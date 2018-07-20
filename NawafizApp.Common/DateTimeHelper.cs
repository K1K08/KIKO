using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NawafizApp.Common
{
    public static class DateTimeHelper
    {
        public static DateTime ConvertStringToDate(string dateAsString, DateFormats format)
        {
            DateTime date = DateTime.MinValue;
            if (format == DateFormats.DD_MM_YYYY)
            {
                date = DateTime.ParseExact(dateAsString, "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            return date;
        }
        public static DateTime ServerNow
        {
            get
            {
                //if (DateTime.Now.Month >= 4 && DateTime.Now.Month <= 11)
                //    return DateTime.Now.AddHours(10);
                //else
                //    return DateTime.Now.AddHours(9);
                return DateTime.Now;
            }
        }
        public static string ConvertDateToString(DateTime date, DateFormats format)
        {
            string dateAsString = "";
            if (format == DateFormats.DD_MM_YYYY)
            {
                dateAsString = date.ToString("dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            return dateAsString;
        }
        public static TimeSpan ConvertStringToTime(string timeAsString, TimeFormats format)
        {
            TimeSpan time = TimeSpan.MinValue;
            timeAsString = FixFuckingTime(timeAsString);
            if (format == TimeFormats.HH_MM_AM)
            {
                time = DateTime.ParseExact(timeAsString, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;
            }
            return time;
        }
        public static string ConvertTimeToString(TimeSpan time, TimeFormats format)
        {
            string timeAsString = "";
            if (format == TimeFormats.HH_MM_AM)
            {
                timeAsString = DateTime.Today.Add(time).ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            }
            return timeAsString;
        }
        public static string FixFuckingTime(string time)
        {
            string newTime = Int32.Parse(time.Split(':')[0]) < 10 && time[0] != '0' ? "0" + time : time;
            return newTime;
        }
    }
    public enum DateFormats { DD_MM_YYYY };
    public enum TimeFormats { HH_MM_AM }
}