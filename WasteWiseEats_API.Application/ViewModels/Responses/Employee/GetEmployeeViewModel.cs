namespace WasteWiseEats_API.Application.ViewModels.Responses.Employee
{
    public class GetEmployeeViewModel
    {
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Phone { get; set; }

        public string Job { get; set; }

    }
}
