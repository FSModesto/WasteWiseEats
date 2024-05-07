using System.Text.RegularExpressions;

namespace WasteWiseEats_API.Domain.Models
{
    public class Phone
    {
        public static readonly string[] DDDS =
            {
                "11", "12", "13", "14", "15", "16", "17", "18", "19",
                "21", "22", "24", "27", "28",
                "31", "32", "33", "34", "35", "37","38",
                "41", "42", "43", "44", "45", "46", "47", "48", "49",
                "51", "53", "54", "55",
                "61", "62", "63", "64", "65", "66", "67", "68", "69",
                "71", "73", "74", "75", "77", "79",
                "81", "82", "83", "84", "85", "86", "87", "88", "89",
                "91", "92", "93", "94", "95", "96", "97", "98", "99"
            };

        public static bool IsValidCellphone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;

            //Regex Celular
            Regex regex = new(@"^[1-9]{2}9\d{8}$");

            return regex.IsMatch(phone);
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;

            //Regex telefone fixou
            Regex regex = new(@"^[1-9]{2}\d{8}$");

            return regex.IsMatch(phone);
        }

        public static bool IsValidPhoneOrCellphone(string phone)
        {
            return IsValidPhone(phone) || IsValidCellphone(phone);
        }

        public static bool IsValidDDD(string phone)
        {
            if (string.IsNullOrEmpty(phone) || phone.Length < 2)
                return false;

            string ddd = phone[..2];

            return DDDS.Contains(ddd);
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;

            //Regex Celular
            Regex regex = new(@"^9\d{8}$");

            string number = phone[2..];

            return regex.IsMatch(number);
        }

        public static (string ddd, string number) SplitPhone(string phone)
        {
            string ddd = phone[..2];
            string number = phone[2..];

            return (ddd, number);
        }
        public static bool IsValidMaskedPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;

            Regex regex = new(@"^[0-9 ()-]+$");

            return regex.IsMatch(phone);
        }

        public static string RemoveMask(string phone)
        {
            return Regex.Replace(phone, @"[\s()-]+", "");
        }
    }
}