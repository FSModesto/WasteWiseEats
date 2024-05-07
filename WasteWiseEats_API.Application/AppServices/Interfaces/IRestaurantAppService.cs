using WasteWiseEats_API.Application.ViewModels.Requests.Restaurant;
using WasteWiseEats_API.Application.ViewModels.Responses.Restaurant;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices.Interfaces
{
    public interface IRestaurantAppService
    {
        Task<IResponse<Guid>> Create(CreateRestaurantViewModel viewModel);

        Task<IResponse<Guid>> Update(UpdateRestaurantViewModel viewModel);

        Task<IResponse> Delete(Guid id);

        Task<IResponse<GetRestaurantViewModel>> Get(Guid id);
    }
}
