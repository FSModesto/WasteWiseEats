using MediatR;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationCenter
{
    public class DeleteDonationCenterCommand : DonationCenterCommand<Unit>
    {
        public DeleteDonationCenterCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
