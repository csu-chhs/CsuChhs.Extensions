namespace CsuChhs.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Attempts to parse and convert a string to the
        /// given enum type by enum name.
        ///
        /// IE, if you have a string state of CO you can attempt to
        /// cast it to a USState enum using this extension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? ToEnum<T>(this string? value) where T : struct
        {
            try
            {
                if(value != null)
                {
                    return (T) Enum.Parse(typeof(T), value);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
