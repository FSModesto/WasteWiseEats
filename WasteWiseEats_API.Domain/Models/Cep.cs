using System.Text.RegularExpressions;

namespace WasteWiseEats_API.Domain.Models
{
    public class Cep
    {
        public static bool IsCEP(string cep)
        {
            cep = cep.Replace(".", "")
                     .Replace("-", "")
                     .Trim();

            Regex regex = new Regex(@"^\d{8}$");

            return regex.IsMatch(cep);
        }
    }
}