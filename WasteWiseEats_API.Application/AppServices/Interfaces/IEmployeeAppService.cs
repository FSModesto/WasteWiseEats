using WasteWiseEats_API.Application.ViewModels.Requests.Employee;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.Employee;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices.Interfaces
{
    public interface IEmployeeAppService
    {
        Task<IResponse<Guid>> Create(CreateEmployeeViewModel viewModel);

        Task<IResponse<Guid>> Update(UpdateEmployeeViewModel viewModel);

        Task<IResponse> Delete(Guid id);

        Task<IResponse<GetEmployeeViewModel>> Get(Guid id);

        Task<IResponse<PagedResultViewModel<GetMinifiedEmployeesViewModel>>> GetAll(EmployeeFilterViewModel viewModel);
    }
}
