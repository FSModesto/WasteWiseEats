namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister
{
    public class FoodSubCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public bool IsPerishable { get; set; }

        public bool HasPrepared { get; set; }
    }
}
