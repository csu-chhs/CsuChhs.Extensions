using System;
using System.Data;

namespace CsuChhs.Extensions
{
    /// <summary>
    /// Includes safe extensions for fetching data without null reference
    /// checks for:
    /// - Double
    /// - Strings
    /// - Ints
    /// - DateTimes
    /// - Booleans
    /// </summary>
    public static class DataExtensions
    {
        /// <summary>
        /// Safely fetch a double value via index.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static double? SafeGetDouble(this IDataReader reader, int colIndex)
        {
            return _SafeGetDouble(reader, colIndex);
        }

        /// <summary>
        /// Safely fetch a double value via column name.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static double? SafeGetDouble(this IDataReader reader, string columnName)
        {
            try
            {
                int colIndex = reader.GetOrdinal(columnName);
                return _SafeGetDouble(reader, colIndex);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Internal method for fetching a double with null
        /// catch.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private static double? _SafeGetDouble(IDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetDouble(colIndex);
            }

            return null;
        }

        /// <summary>
        /// Safely fetch a string value by column index.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static string? SafeGetString(this IDataReader reader, int colIndex)
        {
            return _SafeGetString(reader, colIndex);
        }

        /// <summary>
        /// Safely fetch a string value by column name.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string? SafeGetString(this IDataReader reader, string columnName)
        {
            try
            {
                int colIndex = reader.GetOrdinal(columnName);
                return _SafeGetString(reader, colIndex);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns string value via a column name
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string GetString(this IDataReader reader, string columnName)
        {
            int colIndex = reader.GetOrdinal(columnName);
            return reader.GetString(colIndex);
        }

        /// <summary>
        /// Internal method for fetching string data.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private static string? _SafeGetString(IDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }

            return null;
        }

        /// <summary>
        /// Safely fetch an integer by column index
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static int? SafeGetInt(this IDataReader reader, int colIndex)
        {
            return _SafeGetInt(reader, colIndex);
        }

        /// <summary>
        /// Safely fetch an integer by column name.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int? SafeGetInt(this IDataReader reader, string columnName)
        {
            try
            {
                int colIndex = reader.GetOrdinal(columnName);
                return _SafeGetInt(reader, colIndex);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Internal method for safely fetching an integer.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private static int? _SafeGetInt(IDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetInt16(colIndex);
            }

            return null;
        }

        /// <summary>
        /// Safely fetch date time by column index.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static DateTime? SafeGetDateTime(this IDataReader reader, int colIndex)
        {
            return _SafeGetDateTime(reader, colIndex);
        }

        /// <summary>
        /// Safely fetch a date time by column name
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static DateTime? SafeGetDateTime(this IDataReader reader, string columnName)
        {
            try
            {
                int colIndex = reader.GetOrdinal(columnName);
                return _SafeGetDateTime(reader, colIndex);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Internal method for safely fetching a date time.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private static DateTime? _SafeGetDateTime(IDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                try
                {
                    return reader.GetDateTime(colIndex);
                }
                catch (FormatException)
                {
                    // Date time is not in a correct format that we can parse
                    // return a null value as we cannot parse.
                    return null;
                }
                
            }

            return null;
        }

        /// <summary>
        /// Safely fetch a bool value. This returns false if
        /// the field is null.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static bool SafeGetBool(this IDataReader reader, int colIndex)
        {
            return _SafeGetBool(reader, colIndex);
        }

        /// <summary>
        /// Safely fetch a bool value.  This returns false if
        /// the field is null.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool SafeGetBool(this IDataReader reader, string columnName)
        {
            try
            {
                int colIndex = reader.GetOrdinal(columnName);
                return _SafeGetBool(reader, colIndex);
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Internal method for safely fetching bool values.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private static bool _SafeGetBool(IDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetBoolean(colIndex);
            }

            return false;
        }
    }
}
