using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CsuChhs.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Attempts to get the display name of the enum value.
        ///
        /// Replacement for Humanizer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum? value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            
            var type = value.GetType();
            var member = type.GetMember(value.ToString());

            if (member.Length > 0)
            {
                var attribute = member[0].GetCustomAttribute<DisplayAttribute>();

                if (attribute != null)
                {
                    // Handles resource-based names too
                    return attribute.GetName() ?? string.Empty;
                }
            }

            return value.ToString();
        }
        
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
