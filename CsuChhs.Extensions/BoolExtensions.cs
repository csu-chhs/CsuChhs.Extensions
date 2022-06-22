namespace CsuChhs.Extensions
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Returns "Yes/No" instead of a
        /// standard True/False
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToYesNo(this bool value)
        {
            if(value)
            {
                return "Yes";
            }

            return "No";
        }

        /// <summary>
        /// Nullable version of ToYesNo
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToYesNo(this bool? value)
        {
            if(value == null)
            {
                return "";
            }
            else
            {
                return value.ToYesNo();
            }
        }
    }
}
