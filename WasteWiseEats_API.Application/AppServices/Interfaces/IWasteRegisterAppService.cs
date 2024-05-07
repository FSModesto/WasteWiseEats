using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Requests.WasteRegister;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.WasteRegister;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices.Interfaces
{
    public interface IWasteRegisterAppService
    {
        Task<IResponse<Guid>> Create(CreateWasteRegisterViewModel viewModel);

        Task<IResponse<Guid>> Update(UpdateWasteRegisterViewModel viewModel);

        Task<IResponse> Delete(Guid id);

        Task<IResponse<GetWasteRegisterViewModel>> Get(Guid id);

        Task<IResponse<PagedResultViewModel<GetMinifiedWasteRegistersViewModel>>> GetAll(WasteRegisterFilterViewModel viewModel);
    }
}
