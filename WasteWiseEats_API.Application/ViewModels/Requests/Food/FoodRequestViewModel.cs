namespace WasteWiseEats_API.Application.ViewModels.Requests.Food
{
    public class FoodRequestViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public bool IsPerishable { get; set; }

        public bool HasPrepared { get; set; }
    }
}
