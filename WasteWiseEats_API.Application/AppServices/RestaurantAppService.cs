using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Application.AppServices.Base;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.Restaurant;
using WasteWiseEats_API.Application.ViewModels.Responses.Restaurant;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Restaurant;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices
{
    public class RestaurantAppService : BaseAppService, IRestaurantAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _repository;

        public RestaurantAppService(IMediator mediator, IMapper mapper, IRestaurantRepository repository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResponse<Guid>> Create(CreateRestaurantViewModel viewModel)
        {
            CreateRestaurantCommand command = _mapper.Map<CreateRestaurantCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }

        public async Task<IResponse> Delete(Guid id)
        {
            DeleteRestaurantCommand command = new(id);
            
            await _mediator.Send(command);

            return Success();
        }

        public async Task<IResponse<GetRestaurantViewModel>> Get(Guid id)
        {
            Restaurant restaurant =
                await _repository.Find(wh => wh.Id == id, query => query.Include(entity => entity.Address));

            return Success(_mapper.Map<GetRestaurantViewModel>(restaurant));
        }

        public async Task<IResponse<Guid>> Update(UpdateRestaurantViewModel viewModel)
        {
            UpdateRestaurantCommand command = _mapper.Map<UpdateRestaurantCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }
    }
}
