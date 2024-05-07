using MediatR;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Exceptions;
using WasteWiseEats_API.Domain.Exceptions.Enums;
using WasteWiseEats_API.Domain.Interfaces.Repositories;

namespace WasteWiseEats_API.Domain.CommandHandlers
{
    public class WasteRegisterCommandHandler : IRequestHandler<CreateWasteRegisterCommand, Guid>,
                                               IRequestHandler<UpdateWasteRegisterCommand, Guid>,
                                               IRequestHandler<DeleteWasteRegisterCommand, Unit>,
                                               IRequestHandler<WasteRegisterFeedbackCommand, Unit>
                                
    {
        private readonly IWasteRegisterRepository _repository;

        public WasteRegisterCommandHandler(IWasteRegisterRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateWasteRegisterCommand request, CancellationToken cancellationToken)
        {
            WasteRegister wasteRegister = new()
            {
                //TODO:RestaurantId e Employee deve ser resgatado pelo BearerToken
                HasDonated = false,

                Foods = request.Foods.Select(food => new Food
                {
                    Name = food.Name.ToUpper(),
                    Quantity = food.Quantity.ToLower(),
                    IsPerishable = food.IsPerishable,
                    HasPrepared = food.HasPrepared,
                }).ToList()
            };

            await _repository.Create(wasteRegister);
            return wasteRegister.Id;
        }

        public async Task<Guid> Handle(UpdateWasteRegisterCommand request, CancellationToken cancellationToken)
        {
            WasteRegister wasteRegister = await ValidateWasteRegister(request.Id);

            ICollection<Food> existingFoods = wasteRegister.Foods;

            foreach (FoodSubCommand requestFood in request.Foods)
            {
                Food? existingFood = wasteRegister.Foods.FirstOrDefault(f => f.Id == requestFood.Id);

                if (existingFood is not null)
                {
                    existingFood.Name = requestFood.Name.ToUpper();
                    existingFood.Quantity = requestFood.Quantity.ToLower();
                    existingFood.HasPrepared = requestFood.HasPrepared;
                    existingFood.IsPerishable = requestFood.IsPerishable;

                    existingFoods.Remove(existingFood);
                }
                else
                {
                    existingFood = new Food()
                    {
                        Name = requestFood.Name.ToUpper(),
                        Quantity = requestFood.Quantity.ToLower(),
                        IsPerishable = requestFood.IsPerishable,
                        HasPrepared = requestFood.HasPrepared
                    };

                    wasteRegister.Foods.Add(existingFood);
                }
            }

            foreach (Food foodToRemove in existingFoods)
                wasteRegister.Foods.Remove(foodToRemove);

            await _repository.Update(wasteRegister);
            return wasteRegister.Id;
        }

        public async Task<Unit> Handle(DeleteWasteRegisterCommand request, CancellationToken cancellationToken)
        {
            WasteRegister wasteRegister = await ValidateWasteRegister(request.Id);

            if (wasteRegister.DonationProposal is not null)
                throw new ApiException(EApiException.WasteRegisterDeletionError);

            await _repository.Delete(wasteRegister);

            return Unit.Value;
        }

        public async Task<Unit> Handle(WasteRegisterFeedbackCommand request, CancellationToken cancellationToken)
        {
            WasteRegister wasteRegister = await ValidateWasteRegister(request.Id);

            wasteRegister.HasDonated = true;

            await _repository.Update(wasteRegister);

            return Unit.Value;
        }

        private async Task<WasteRegister> ValidateWasteRegister(Guid id)
        {
            WasteRegister wasteRegister = 
                await _repository.Find(wh => wh.Id == id, query => query.Include(entity => entity.Foods)
                                                                        .Include(entity => entity.DonationProposal));

            if (wasteRegister is null)
                throw new ApiException(EApiException.WasteRegisterNotFound);

            return wasteRegister;
        }
    }
}
