namespace WasteWiseEats_API.Application.ViewModels.Requests.Employee
{
    public class UpdateEmployeeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Phone { get; set; }

        public string Job { get; set; }
    }
}
