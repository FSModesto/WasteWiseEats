using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;

namespace WasteWiseEats_API.Domain.Extensions
{
    public static class GenericExtension
    {
        public static string ToJson<T>(this T obj, Formatting formatting = Formatting.Indented, IContractResolver? contractResolver = null)
        {
            if (obj is null)
                return string.Empty;

            contractResolver ??= new CamelCasePropertyNamesContractResolver();

            string json =
                JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = formatting,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return json;
        }

        public static T DeserializeJson<T>(this string json)
        {
            if (!json.TryDeserializeJson(out T deserialized))
                throw new Exception("Falha ao deserializar json.");

            return deserialized;
        }

        public static bool TryDeserializeJson<T>(this string json, out T resultParsed)
        {
            resultParsed = default;

            if (typeof(T) == typeof(string))
            {
                resultParsed = json.Convert<T>();

                return true;
            }

            try
            {
                JsonSerializerSettings jsonSettings = new()
                {
                    Error = (sender, args) =>
                    {
                        Log.Error("Falha de deserialização: {member}: {message}", args.ErrorContext.Member, args.ErrorContext.Error.Message);
                    }
                };

                resultParsed = JsonConvert.DeserializeObject<T>(json, jsonSettings);

                return resultParsed != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static T Convert<T>(this string str, T @default = default, string cultureName = "en-US")
        {
            if (string.IsNullOrEmpty(str))
                return @default;

            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

                CultureInfo culture = new(cultureName, false);

                if (converter != null)
                    return (T)converter.ConvertFromString(null, culture, str);

                return @default;
            }
            catch (Exception ex)
            {
                Log.Warning("Falha de conversão: {ex}", ex.Message);
                return @default;
            }
        }

        public static string GetColumnName(this MemberInfo member)
        {
            if (member is null)
                return null;

            ColumnAttribute attribute =
                (ColumnAttribute)Attribute.GetCustomAttribute(member, typeof(ColumnAttribute), false);

            return (attribute?.Name ?? member.Name).ToLower();
        }

        public static string ToStringList<T>(this IEnumerable<T> source, string separator = ",")
        {
            return string.Join(separator, source);
        }

        public static TClass TrimAll<TClass>(this TClass @class) where TClass : class
        {
            if (@class is null)
                return null;

            IEnumerable<PropertyInfo> propertiesInfo =
                @class.GetType()
                      .GetProperties();

            foreach (PropertyInfo propertyInfo in propertiesInfo)
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    string oldValue = (string)propertyInfo.GetValue(@class, null);

                    propertyInfo.SetValue(@class, oldValue?.Trim(), null);
                }
                else if (propertyInfo.PropertyType.IsClass)
                {
                    object oldValue = propertyInfo.GetValue(@class, null);

                    if (oldValue is IEnumerable enumerable)
                    {
                        foreach (var item in enumerable)
                            item.TrimAll();

                        continue;
                    }

                    propertyInfo.SetValue(@class, oldValue.TrimAll(), null);
                }
            }

            return @class;
        }

        public static List<TClass> TrimAll<TClass>(this IEnumerable<TClass> classes) where TClass : class
        {
            foreach (TClass @class in classes)
                @class.TrimAll();

            return classes.ToList();
        }

        public static async Task<byte[]> ToBytes(this Stream stream)
        {
            using MemoryStream memoryStream = new();

            await stream.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }

        public static T TakeSnapshot<T>(this T source, T @default = default)
        {
            if (source is null)
                return @default;

            string json = source.ToJson();

            return json.DeserializeJson<T>();
        }

        public static string GetPropertyDisplayName(this PropertyInfo propertyInfo)
        {
            return propertyInfo
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Select(attribute => ((DisplayAttribute)attribute).Name)
                .DefaultIfEmpty(propertyInfo.Name)
                .FirstOrDefault();
        }

        public static bool IsIn<T>(this T source, params T[] values)
        {
            return values.Contains(source);
        }
    }
}
