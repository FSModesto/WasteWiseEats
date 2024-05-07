namespace WasteWiseEats_API.Domain.Models
{
    public class Document
    {
        public static bool IsCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = Unmasked(cpf);

            if (cpf.Length != 11)
                return false;

            if (GenerateInvalidDocument(11).Contains(cpf))
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);

            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult1[i];

            int mod = sum % 11;

            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            string digit = mod.ToString();

            tempCpf += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult2[i];

            mod = sum % 11;

            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            digit += mod.ToString();

            return cpf.EndsWith(digit);
        }

        public static bool IsCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            int[] mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = Unmasked(cnpj);

            if (cnpj.Length != 14)
                return false;

            if (GenerateInvalidDocument(14).Contains(cnpj))
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * mult1[i];

            int mod = sum % 11;

            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            string digit = mod.ToString();

            tempCnpj += digit;

            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * mult2[i];

            mod = sum % 11;

            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            digit += mod.ToString();

            return cnpj.EndsWith(digit);
        }

        /// <summary>
        /// Gera padrões conhecidos que burlam o digito verificador, como "11111111111"
        /// </summary>
        private static string[] GenerateInvalidDocument(int lenght)
        {
            List<string> invalids = new();

            for (int i = 0; i <= 9; i++)
                invalids.Add(new string(Convert.ToChar(i.ToString()), lenght).ToString());

            return invalids.ToArray();
        }

        public static string GetMasked(string document)
        {
            if (IsCPF(document))
                return Convert.ToUInt64(document).ToString(@"000\.000\.000\-00");

            if (IsCNPJ(document))
                return Convert.ToUInt64(document).ToString(@"00\.000\.000\/0000\-00");

            return document;
        }

        public static string Unmasked(string document)
        {
            return document.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        }
    }
}
