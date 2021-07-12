using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CsuChhs.Extensions
{
    /// <summary>
    /// Collection of string extensions for CHHS projects.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a possible URL without scheme into
        /// one with an acceptable scheme.
        ///
        /// Introduced with CHHS.Common.Core.1.1.1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUrl(this string value)
        {
            return new UriBuilder(value).Uri.ToString();
        }

        /// <summary>
        /// Adds a string extension to Truncate strings to a certain length.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }

        /// <summary>
        /// Adds a string extension to safely lower strings that can
        /// be null.  Helpful in LINQ statements where using || with ? is illegal.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeToLower(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.ToLower();
        }

        /// <summary>
        /// String formatter to turn a string into a
        /// formatted phone number.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPhoneNumber(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                //Remove characters
                string phone = value.Replace(" ", "")
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("-", "");

                switch (phone.Length)
                {
                    case 7:
                        return Convert.ToInt64(phone).ToString("###-####");

                    case 10:
                        return Convert.ToInt64(phone).ToString("(###) ###-####");

                    case 11:
                        return Convert.ToInt64(phone).ToString("+# (###) ###-####");

                    default:
                        return phone;
                }
            }

            return "";
        }

        /// <summary>
        /// Removes all non-numeric characters from the string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNumeric(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return Regex.Replace(value, @"[^0-9]+", "");
        }

        /// <summary>
        /// Converts the string time to a DateTime time.
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string dateString)
        {
            return DateTime.ParseExact(dateString, "h:mm tt", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// This cleans a string for use in a CSV file.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static string ToCsvString(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value.Replace(",", ";")
                    .Replace("'", "")
                    .Replace("\"", "")
                    .Replace(System.Environment.NewLine, " ");
            }
            return value;
        }

        /// <summary>
        /// String formatter to turn a decimal into a
        /// formatted currency.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C");
        }

        /// <summary>
        /// String formatter to turn a nullable decimal into a
        /// formatted currency.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCurrency(this decimal? value)
        {
            return value?.ToString("C");
        }

        /// <summary>
        /// String formatter to turn a double into a
        /// formatted currency.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCurrency(this double value)
        {
            return value.ToString("C");
        }

        /// <summary>
        /// String formatter to turn a nullable double into a
        /// formatted currency.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCurrency(this double? value)
        {
            return value?.ToString("C");
        }

        /// <summary>
        /// String formatter to turn an int into a
        /// formatted currency.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCurrency(this int value)
        {
            return value.ToString("C");
        }

        /// <summary>
        /// String formatter to turn a nullable int into a
        /// formatted currency.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCurrency(this int? value)
        {
            return value?.ToString("C");
        }

        /// <summary>
        /// Converts a scanned in CSUID into a valid CSUID.  The barcode
        /// scanner usually scans in extra digits (such as the card version) along with
        /// the CSUID.  This extension trims those digits off.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToScannedInCsuId(this string value)
        {
            if (value.Length > 9)
            {
                return value.Substring(0, 9);
            }

            return value;
        }

        /// <summary>
        /// Determines if the string value is numeric or not.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string value)
        {
            try
            {
                _=Int32.Parse(value);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Transform a string to an integer.  Returns
        /// a nullable int if the conversion is not possible.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToNullableInt(this string value)
        {
            if (value.IsNumeric())
            {
                return Int32.Parse(value);
            }

            return null;
        }

        /// <summary>
        /// Converts a string to an integer. Throws
        /// an argument null exception if it cannot be converted.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            if (value.IsNumeric())
            {
                return Int32.Parse(value);
            }

            throw new ArgumentNullException("value",
                "String is null or otherwise unable to be converted to an integer.");
        }
        
        /// <summary>
        /// Provides some decoding for ASCII characters that are embedded in a 
        /// string.  Currently this includes changing &#39; to apostrophes.
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DecodeAscii(this string value)
        {
            return value.Replace("&#39;", "'");
        }

        /// <summary>
        /// Changes the ending of a word to be plural if the count is not 1,
        /// otherwise leaves it the same.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count">The number of items. Determines if it is plural or singular.</param>
        /// <param name="customEnding">Optional custom ending for exceptions to the normal rule.</param>
        /// <returns>A string that has been adjusted to be singular or plural depending on the count.</returns>
        public static string Pluralize(this string value, int count, string? customEnding = null)
        {
            if (count == 1)
            {
                return value;
            }

            if (customEnding != null)
            {
                return $"{value}{customEnding}";
            }

            string valueLowerCase = value.ToLower();
            if (
                valueLowerCase.EndsWith("x") || 
                valueLowerCase.EndsWith("s") || 
                valueLowerCase.EndsWith("z") ||
                valueLowerCase.EndsWith("sh") ||
                valueLowerCase.EndsWith("ch")
            )
            {
                // box => boxes, atlas => atlases, match => matches
                return $"{value}es";
            }

            if (valueLowerCase.EndsWith("y"))
            {
                // tally => tallies
                return $"{value.Substring(0, value.Length - 1)}ies";
            }

            // paper => papers
            return $"{value}s";
        }
    }
}
