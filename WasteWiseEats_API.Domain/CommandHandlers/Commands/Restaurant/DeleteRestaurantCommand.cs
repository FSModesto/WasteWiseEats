using MediatR;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Restaurant
{
    public class DeleteRestaurantCommand : RestaurantCommand<Unit>
    {
        public DeleteRestaurantCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
