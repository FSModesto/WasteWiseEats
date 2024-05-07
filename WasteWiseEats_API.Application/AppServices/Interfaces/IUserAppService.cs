using WasteWiseEats_API.Application.ViewModels.Requests.User;
using WasteWiseEats_API.Application.ViewModels.Responses.Authentications;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices.Interfaces
{
    public interface IUserAppService
    {
        Task<IResponse<Guid>> Create(CreateUserViewModel viewModel);

        Task<IResponse<AuthenticatedViewModel<AuthenticatedUserViewModel>>> Login(LoginViewModel viewModel);
    }
}
