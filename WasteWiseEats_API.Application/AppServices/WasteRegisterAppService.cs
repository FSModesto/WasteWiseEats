using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Application.AppServices.Base;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Requests.WasteRegister;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.WasteRegister;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Interfaces;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Application.AppServices
{
    public class WasteRegisterAppService : BaseAppService, IWasteRegisterAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IWasteRegisterRepository _repository;

        public WasteRegisterAppService(IMediator mediator, IMapper mapper, IWasteRegisterRepository repository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResponse<Guid>> Create(CreateWasteRegisterViewModel viewModel)
        {
            CreateWasteRegisterCommand command = _mapper.Map<CreateWasteRegisterCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }

        public async Task<IResponse> Delete(Guid id)
        {
            DeleteWasteRegisterCommand command = new(id);

            await _mediator.Send(command);

            return Success();
        }

        public async Task<IResponse<GetWasteRegisterViewModel>> Get(Guid id)
        {
            WasteRegister wasteRegister =
                await _repository.Find(wh => wh.Id == id, query => query.Include(entity => entity.Foods));

            return Success(_mapper.Map<GetWasteRegisterViewModel>(wasteRegister));
        }

        public async Task<IResponse<PagedResultViewModel<GetMinifiedWasteRegistersViewModel>>> GetAll(WasteRegisterFilterViewModel viewModel)
        {
            WasteRegisterFilter filter = _mapper.Map<WasteRegisterFilter>(viewModel);

            PagedResult<WasteRegister> wasteRegisters = await _repository.GetFilteredByRestaurant(filter);

            return Success(_mapper.Map<PagedResultViewModel<GetMinifiedWasteRegistersViewModel>>(wasteRegisters.Results.OrderByDescending(wh => wh.CreatedAt)));
        }

        public async Task<IResponse<Guid>> Update(UpdateWasteRegisterViewModel viewModel)
        {
            UpdateWasteRegisterCommand command = _mapper.Map<UpdateWasteRegisterCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }
    }
}
