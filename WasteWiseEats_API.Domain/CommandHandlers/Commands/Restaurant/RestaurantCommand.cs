using MediatR;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Address;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Base;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Restaurant
{
    public abstract class RestaurantCommand<TResponse> : Command<TResponse>
    {
        public string Name { get; set; }

        public string Document { get; set; }

        public string Owner { get; set; }

        public string OwnerDocument { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TimeSpan DonationTime { get; set; }

        public RestaurantAddressSubCommand Address { get; set; }
    }

    public class RestaurantAddressSubCommand : AddressSubCommand
    {
    }
}
