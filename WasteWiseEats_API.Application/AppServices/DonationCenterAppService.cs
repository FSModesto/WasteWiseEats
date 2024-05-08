using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Application.AppServices.Base;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.DonationCenter;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Application.ViewModels.Responses.DonationCenter;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationCenter;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices
{
    public class DonationCenterAppService : BaseAppService, IDonationCenterAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IDonationCenterRepository _repository;

        public DonationCenterAppService(IMediator mediator, IMapper mapper, IDonationCenterRepository repository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResponse<Guid>> Create(CreateDonationCenterViewModel viewModel)
        {
            CreateDonationCenterCommand command = _mapper.Map<CreateDonationCenterCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }

        public async Task<IResponse> Delete(Guid id)
        {
            DeleteDonationCenterCommand command = new(id);

            Unit response = await _mediator.Send(command);

            return Success(response);
        }

        public async Task<IResponse<GetDonationCenterViewModel>> Get(Guid id)
        {
            DonationCenter donationCenter =
                await _repository.Find(wh => wh.Id == id, query => query.Include(entity => entity.Address));

            return Success(_mapper.Map<GetDonationCenterViewModel>(donationCenter));
        }

        public async Task<IResponse<IEnumerable<GetMinifiedDonationCentersViewModel>>> GetAll(string state, TimeSpan workingTime)
        {
            IEnumerable<DonationCenter> donationCenters = await _repository.GetByStateAndTime(state, workingTime);

            return Success(_mapper.Map<IEnumerable<GetMinifiedDonationCentersViewModel>>(donationCenters));
        }

        public async Task<IResponse<Guid>> Update(UpdateDonationCenterViewModel viewModel)
        {
            UpdateDonationCenterCommand command = _mapper.Map<UpdateDonationCenterCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }
    }
}
