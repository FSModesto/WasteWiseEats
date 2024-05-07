using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WasteWiseEats_API.Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T source) where T : Enum
        {
            try
            {
                return source.GetType()
                             .GetField(source.ToString())
                             .GetCustomAttributes(typeof(DescriptionAttribute), false)
                             .Select(attribute => ((DescriptionAttribute)attribute).Description)
                             .DefaultIfEmpty(source.ToString())
                             .FirstOrDefault();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetDisplayName<T>(this T source) where T : Enum
        {
            try
            {
                return source.GetType()
                       .GetField(source.ToString())
                       .GetCustomAttributes(typeof(DisplayAttribute), false)
                       .Select(attribute => ((DisplayAttribute)attribute).Name)
                       .DefaultIfEmpty(source.ToString())
                       .FirstOrDefault();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static T GetByDescription<T>(this string description) where T : Enum
        {
            if (string.IsNullOrEmpty(description))
                return default;

            FieldInfo[] fields = typeof(T).GetFields();

            foreach (FieldInfo field in fields)
            {
                Attribute attribute =
                    Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

                if (attribute is DescriptionAttribute descriptionAttribute && descriptionAttribute.Description.ToUpper() == description.ToUpper())
                    return (T)field.GetValue(null);

                else if (field.Name.ToUpper() == description.ToUpper())
                    return (T)field.GetValue(null);
            }

            return default;
        }

        public static IEnumerable<T> GetValues<T>(bool skipFirst = false) where T : Enum
        {
            IEnumerable<T> values =
                Enum.GetValues(typeof(T))
                    .Cast<T>();

            if (skipFirst)
                return values.Skip(1);

            return values;
        }

        public static int GetSum<T>() where T : Enum
        {
            return GetValues<T>().Sum(e => e.ToInt());
        }

        public static int ToInt<TValue>(this TValue value) where TValue : Enum
        {
            return (int)(object)value;
        }

        public static int GetSelectedFlagsCount<T>(this T value) where T : Enum
        {
            return new BitArray(new[] { (int)(object)value }).OfType<bool>().Count(x => x);
        }
    }
}
