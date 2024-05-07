namespace WasteWiseEats_API.Domain.Models
{
    public class State
    {
        public int Id { get; set; }

        public string Acronym { get; set; }

        public string Name { get; set; }

        public static readonly string[] UFs =
        {
            "AC","AL","AP","AM","BA","CE","ES","GO","MA",
            "MT","MS","MG","PA","PB","PR","PE","PI","RJ",
            "RN","RS","RO","RR","SC","SP","SE","TO","DF"
        };

        public static bool IsValidState(string state)
        {
            if (string.IsNullOrEmpty(state) || state.Length != 2)
                return false;

            return UFs.Contains(state);
        }
    }
}
