using MediatR;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Address;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Base;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationCenter
{
    public abstract class DonationCenterCommand<TResponse> : Command<TResponse>
    {
        public string Name { get; set; }

        public string Owner { get; set; }

        public string OwnerDocument { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TimeSpan BeginTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DonationCenterAddressSubCommand Address { get; set; }
    }

    public class DonationCenterAddressSubCommand : AddressSubCommand
    {
    }
}
