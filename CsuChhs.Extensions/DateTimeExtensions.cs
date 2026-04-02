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
        
        public static string ToPrettyTime(this DateTime dateTime, DateTime? referenceTime = null)
        {
            var now = referenceTime ?? DateTime.UtcNow;

            if (dateTime.Kind == DateTimeKind.Unspecified)
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

            var ts = now - dateTime;
            var delta = ts.TotalSeconds;

            // If more than 24 hours (past or future), show normal date
            if (Math.Abs(delta) >= 86400)
                return dateTime.ToString("g"); // e.g. 4/2/2026 3:45 PM

            bool isFuture = delta < 0;
            delta = Math.Abs(delta);

            string suffix = isFuture ? "from now" : "ago";

            if (delta < 5)
                return "just now";

            if (delta < 60)
                return $"{(int)delta} seconds {suffix}";

            if (delta < 120)
                return isFuture ? "in a minute" : "a minute ago";

            if (delta < 3600)
                return $"{(int)(delta / 60)} minutes {suffix}";

            if (delta < 7200)
                return isFuture ? "in an hour" : "an hour ago";

            return $"{(int)(delta / 3600)} hours {suffix}";
        }
    }
}
