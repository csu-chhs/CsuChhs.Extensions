using System;
using System.Collections.Generic;
using System.Text;

namespace CsuChhs.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Takes in the number of decimal places to truncate the double to.
        /// Returns an exact truncation of the decimals to avoid rounding 
        /// up. Returns null if num is null.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="roundTo"></param>
        /// <returns></returns>
        public static double? TruncateDecimals(this double? num, int roundTo)
        {
            if (num != null)
            {
                try
                {
                    return TruncateDecimals((double)num, roundTo);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    throw ex;
                }
            }

            return null;
        }

        /// <summary>
        /// Takes in the number of decimal places to truncate the double to.
        /// Returns an exact truncation of the decimals to avoid rounding 
        /// up.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="roundTo"></param>
        /// <returns></returns>
        public static double TruncateDecimals(this double num, int roundTo)
        {
            if (roundTo < 0)
            {
                throw new ArgumentOutOfRangeException("roundTo can not be negative");
            }

            int roundAmount = (int)Math.Pow(10, roundTo);

            num = Math.Truncate(num * roundAmount) / roundAmount;

            return num;
        }

        /// <summary>
        /// Provides the percent that one number represents of another.
        /// </summary>
        /// <param name="num">The number you have</param>
        /// <param name="total">The total number from which you want to derive your number's percentage</param>
        /// <param name="decimalPlaces">The number of decimal places you want in your double</param>
        /// <seealso cref="ToIntPercent(double, double)"/>
        /// <returns>A double that represents the percent your original number makes up of the total.</returns>
        public static double ToPercent(this double num, double total, int decimalPlaces = 0)
        {
            if (total == 0.0)
            {
                throw new DivideByZeroException();
            }
            return Math.Round((num / total) * 100, decimalPlaces, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Quick way to get a simple integer number representing your number's percentage of another number.
        /// Rounds up or down to nearest whole number.
        /// </summary>
        /// <param name="num">The number you have</param>
        /// <param name="total">The total number from which you want to derive your number's percentage</param>
        /// <returns>An integer representing the percentage of num/total.</returns>
        public static int ToIntPercent(this double num, double total)
        {
            try
            {
                return (int)num.ToPercent(total);
            } 
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
        }
    }
}
