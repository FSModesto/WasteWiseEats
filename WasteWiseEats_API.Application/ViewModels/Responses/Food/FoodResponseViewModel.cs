namespace WasteWiseEats_API.Application.ViewModels.Responses.Food
{
    public class FoodResponseViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public bool IsPerishable { get; set; }

        public bool HasPrepared { get; set; }
    }
}
