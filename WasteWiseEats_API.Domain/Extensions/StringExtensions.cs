using System.Globalization;
using System.Text.RegularExpressions;

namespace WasteWiseEats_API.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string AsOnlyNumbersAndLetters(this string str)
        {
            Regex rgx = new("[^a-zA-Z0-9]");

            return rgx.Replace(str, "");
        }

        public static bool HasOnlyNumbers(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            return str.All(char.IsDigit);
        }

        public static string ToTitleCase(this string str)
        {
            TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;

            return textInfo.ToTitleCase(str);
        }

        public static bool IsValidUri(this string uri)
        {
            bool result = Uri.TryCreate(uri, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
                return value;

            return value[..maxLength];
        }

        public static bool HasOnlyNumbersOrLetters(this string str)
        {
            Regex regex = new("^[a-zA-Z0-9]+$");

            return regex.IsMatch(str);
        }
    }
}
