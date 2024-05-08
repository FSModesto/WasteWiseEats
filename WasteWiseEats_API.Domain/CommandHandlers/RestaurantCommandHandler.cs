using MediatR;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Restaurant;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Exceptions;
using WasteWiseEats_API.Domain.Exceptions.Enums;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Interfaces.Services;
using WasteWiseEats_API.Domain.Models;

namespace WasteWiseEats_API.Domain.CommandHandlers
{
    public class RestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Guid>,
                                            IRequestHandler<UpdateRestaurantCommand, Guid>,
                                            IRequestHandler<DeleteRestaurantCommand, Unit>
    {
        private readonly IRestaurantRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public RestaurantCommandHandler(IRestaurantRepository repository, IAuthenticationService authenticationService, IUserRepository userRepository)
        {
            _repository = repository;
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            User user =
                await _userRepository.Find(wh => wh.Id == _authenticationService.GetUserIdFromToken(), query => query.Include(i => i.Restaurant));

            if (user is null)
                throw new ApiException(EApiException.UserNotFound);

            if (user.Restaurant is not null)
                throw new ApiException(EApiException.UserAlreadyHasRestaurant);

            if (await _repository.Exists(wh => wh.Document == request.Document))
                throw new ApiException(EApiException.RestaurantAlreadyExists);

            Restaurant restaurant = new()
            {
                UserId = user.Id,
                Name = request.Name,
                Document = request.Document,
                Owner = request.Owner,
                OwnerDocument = request.OwnerDocument,
                DonationTime = request.DonationTime,
                Phone = Phone.RemoveMask(request.Phone),
                Email = request.Email,

                Address = new RestaurantAddress()
                {
                    Street = request.Address.Street,
                    Number = request.Address.Number,
                    Complement = request.Address.Complement,
                    ZipCode = request.Address.ZipCode,
                    District = request.Address.District,
                    City = request.Address.City,
                    State = request.Address.State,
                }
            };

            await _repository.Create(restaurant);
            return restaurant.Id;
        }

        public async Task<Guid> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            Restaurant restaurant = await ValidateRestaurant(request.Id);

            restaurant.Name = request.Name;
            restaurant.Document = request.Document;
            restaurant.Owner = request.Owner;
            restaurant.OwnerDocument = request.OwnerDocument;
            restaurant.DonationTime = request.DonationTime;
            restaurant.Phone = Phone.RemoveMask(request.Phone);
            restaurant.Email = request.Email;

            restaurant.Address.Street = request.Address.Street;
            restaurant.Address.Number = request.Address.Number;
            restaurant.Address.City = request.Address.City;
            restaurant.Address.State = request.Address.State;
            restaurant.Address.ZipCode = request.Address.ZipCode;
            restaurant.Address.District = request.Address.District;
            restaurant.Address.Complement = request.Address.Complement;

            await _repository.Update(restaurant);
            return restaurant.Id;
        }

        public async Task<Unit> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            Restaurant restaurant = await ValidateRestaurant(request.Id);

            await _repository.Delete(restaurant);

            return Unit.Value;
        }

        private async Task<Restaurant> ValidateRestaurant(Guid id)
        {
            Restaurant restaurant =
                await _repository.Find(wh => wh.Id == id, query => query.Include(entity => entity.Address));

            if (restaurant is null)
                throw new ApiException(EApiException.RestaurantNotFound);

            return restaurant;
        }
    }
}
