using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CsuChhs.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Adds an Enumeration type method for returning the [Display(Name = "Name")]
        /// from an Enumeration.  Helpful when an enumeration is used on a model 
        /// and you need the display value somewhere in the template or in a controller.
        /// 
        /// If being called on a dynamic you need to call the method directly and pass
        /// in the Enumeration
        /// 
        /// @EnumExtensions.GetDisplayName(ViewBag.student.Seeking)
        /// 
        /// If being called on a type you can simply use GetDisplayName()
        /// 
        /// Student.Seeking.GetDisplayName();
        /// 
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
