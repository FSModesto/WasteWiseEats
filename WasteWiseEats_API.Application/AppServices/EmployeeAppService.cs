using AutoMapper;
using MediatR;
using WasteWiseEats_API.Application.AppServices.Base;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.Employee;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.Employee;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Employee;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Interfaces;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Application.AppServices
{
    public class EmployeeAppService : BaseAppService, IEmployeeAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;

        public EmployeeAppService(IMediator mediator, IMapper mapper, IEmployeeRepository repository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResponse<Guid>> Create(CreateEmployeeViewModel viewModel)
        {
            CreateEmployeeCommand command = _mapper.Map<CreateEmployeeCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }

        public async Task<IResponse> Delete(Guid id)
        {
            DeleteEmployeeCommand command = new(id);

            await _mediator.Send(command);

            return Success();
        }

        public async Task<IResponse<GetEmployeeViewModel>> Get(Guid id)
        {
            Employee employee = await _repository.Get(id);

            return Success(_mapper.Map<GetEmployeeViewModel>(employee));
        }

        public async Task<IResponse<PagedResultViewModel<GetMinifiedEmployeesViewModel>>> GetAll(EmployeeFilterViewModel viewModel)
        {
            EmployeeFilter filter = _mapper.Map<EmployeeFilter>(viewModel);

            PagedResult<Employee> employees = await _repository.GetFilteredByRestaurant(filter);

            return Success(_mapper.Map<PagedResultViewModel<GetMinifiedEmployeesViewModel>>(employees.Results.OrderBy(o => o.Name)));
        }

        public async Task<IResponse<Guid>> Update(UpdateEmployeeViewModel viewModel)
        {
            UpdateEmployeeCommand command = _mapper.Map<UpdateEmployeeCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }
    }
}
