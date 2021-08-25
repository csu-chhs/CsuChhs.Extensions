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
    }
}
