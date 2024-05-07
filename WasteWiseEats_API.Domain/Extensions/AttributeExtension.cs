namespace WasteWiseEats_API.Domain.Extensions
{
    public static class AttributeExtension
    {
        public static TAttribute GetEnumAttribute<TEnum, TAttribute>(this TEnum source) where TEnum : Enum where TAttribute : Attribute
        {
            return (TAttribute)source.GetType()
                                     .GetField(source.ToString())
                                     .GetCustomAttributes(typeof(TAttribute), false)
                                     .FirstOrDefault();

        }
    }
}
