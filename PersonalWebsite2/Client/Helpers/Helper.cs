using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PersonalWebsite2.Client.Helpers
{
    public class Helper
    {
        public static string DisplayNameFor(Type modelType, string propertyName)
        {
            var attribute = modelType.GetProperty(propertyName).GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            if (attribute == null) return string.Empty;

            return attribute.Name;
        }
    }
}
