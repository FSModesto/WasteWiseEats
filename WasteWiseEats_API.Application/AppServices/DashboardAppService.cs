using AutoMapper;
using WasteWiseEats_API.Application.AppServices.Base;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.Dashboard;
using WasteWiseEats_API.Application.ViewModels.Responses.Dashboard;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices
{
    public class DashboardAppService : BaseAppService, IDashboardAppService
    {
        private readonly IMapper _mapper;
        private readonly IWasteRegisterRepository _repository;


        public DashboardAppService(IMapper mapper, IWasteRegisterRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResponse<IEnumerable<DashboardResponseViewModel>>> Get(DashboardFilterViewModel viewModel)
        {
            DashboardFilter filter = _mapper.Map<DashboardFilter>(viewModel);

            IEnumerable<WasteRegister> response = await _repository.GetForDashboard(filter);

            IEnumerable<DashboardResponseViewModel> results = response.Select(result => new DashboardResponseViewModel
            {
                Label = "Desperdício",
                Value = response.Count()
            });

            return Success(results);
        }
    }
}
