using System;
using System.Globalization;

namespace CsuChhs.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekday(this DateTime dateTimeValue)
        {
            switch (dateTimeValue.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return false;

                case DayOfWeek.Sunday:
                    return false;

                default:
                    return true;
            }
        }

        public static bool IsMonday(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsTuesday(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsWednesday(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Wednesday:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsThursday(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Thursday:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsFriday(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsSaturday(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsSunday(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return true;

                default:
                    return false;
            }

        }

        public static string ToPrettyTime(this DateTime dateTime)
        {
            // 1.
            // Get time span elapsed since the date.
            TimeSpan s = DateTime.Now.Subtract(dateTime);

            // 2.
            // Get total number of days elapsed.
            int dayDiff = (int)s.TotalDays;

            // 3.
            // Get total number of seconds elapsed.
            int secDiff = (int)s.TotalSeconds;

            // 4.
            // Don't allow out of range values.
            if (dayDiff < 0)
            {
                return null;
            }

            // 5.
            // Handle same-day times.
            if (dayDiff == 0)
            {
                // A.
                // Less than one minute ago.
                if (secDiff < 60)
                {
                    return "just now";
                }
                // B.
                // Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                // C.
                // Less than one hour ago.
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago",
                        Math.Floor((double)secDiff / 60));
                }
                // D.
                // Less than 2 hours ago.
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }
                // E.
                // Less than one day ago.
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            // 6.
            // Handle previous days.
            if (dayDiff == 1)
            {
                return "yesterday";
            }

            if (dayDiff < 7)
            {
                return string.Format("{0} days ago",
                    dayDiff);
            }

            return string.Format("{0} weeks ago",
                Math.Ceiling((double)dayDiff / 7));
        }

        /// <summary>
        /// This extension returns a consistent value accross operating
        /// systems for the .ToShortTimeString(); for Datetimes.  While
        /// it is sometimes important to show them to users in their specific
        /// culture value, we also use this in places internally to compare values.  This
        /// prevents those comparisons from failing if the code is running on Linux vs Windows,
        /// most notably this is in tests using GitHub Actions as those are ran
        /// on Ubuntu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToConsistentShortTimeString(this DateTime value)
        {
            return value.ToString("h:mm tt", new CultureInfo("en-us"));
        }
    }
}
