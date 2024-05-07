using WasteWiseEats_API.Application.ViewModels.Requests.Dashboard;
using WasteWiseEats_API.Application.ViewModels.Responses.Dashboard;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices.Interfaces
{
    public interface IDashboardAppService
    {
        Task<IResponse<IEnumerable<DashboardResponseViewModel>>> Get(DashboardFilterViewModel viewModel);
    }
}
