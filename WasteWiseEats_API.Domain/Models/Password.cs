using System.Text.RegularExpressions;

namespace WasteWiseEats_API.Domain.Models
{
    public class Password
    {
        public const int MinLenght = 12;

        public static bool HasLenght(string password)
        {
            return password?.Length >= MinLenght;
        }

        public static bool HasNumber(string password)
        {
            Regex regex = new(@"[0-9]+");

            return regex.IsMatch(password);
        }

        public static bool HasUpper(string password)
        {
            Regex regex = new(@"[A-Z]+");

            return regex.IsMatch(password);
        }

        public static bool HasSpecialCharacter(string password)
        {
            Regex regex = new(@"[+=/°!@#$%^&*(),¹²³§£¢¬.\][?:;{}|<>\\¨_-]+");

            return regex.IsMatch(password);
        }
    }
}