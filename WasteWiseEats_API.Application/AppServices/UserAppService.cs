using AutoMapper;
using MediatR;
using WasteWiseEats_API.Application.AppServices.Base;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.User;
using WasteWiseEats_API.Application.ViewModels.Responses.Authentications;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.User;
using WasteWiseEats_API.Domain.Models.Authentications;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserAppService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResponse<Guid>> Create(CreateUserViewModel viewModel)
        {
            CreateUserCommand command = _mapper.Map<CreateUserCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }

        public async Task<IResponse<AuthenticatedViewModel<AuthenticatedUserViewModel>>> Login(LoginViewModel viewModel)
        {
            UserAuthenticationCommand command =
                _mapper.Map<UserAuthenticationCommand>(viewModel);

            Authenticated<AuthenticatedUser> authentication =
                await _mediator.Send(command);

            return Success(_mapper.Map<AuthenticatedViewModel<AuthenticatedUserViewModel>>(authentication));
        }
    }
}
