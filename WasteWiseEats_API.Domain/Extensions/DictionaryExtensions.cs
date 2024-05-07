namespace WasteWiseEats_API.Domain.Extensions
{
    public static class DictionaryExtensions
    {
        public static string ToReadable<T, V>(this Dictionary<T, V> d)
        {
            return string.Join(Environment.NewLine, d.Select(a => $"{a.Key}: {a.Value}"));
        }
    }
}
