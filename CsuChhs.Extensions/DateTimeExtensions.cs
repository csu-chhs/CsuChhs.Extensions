using System.Globalization;

namespace CsuChhs.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns true if the date time is a weekday (M - F)
        /// </summary>
        /// <param name="dateTimeValue"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns true if the date time is a Monday
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
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
