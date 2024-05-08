using MediatR;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Employee;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Exceptions;
using WasteWiseEats_API.Domain.Exceptions.Enums;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Interfaces.Services;
using WasteWiseEats_API.Domain.Models;

namespace WasteWiseEats_API.Domain.CommandHandlers
{
    public class EmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>,
                                            IRequestHandler<UpdateEmployeeCommand, Guid>,
                                            IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public EmployeeCommandHandler(IEmployeeRepository repository, IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.Exists(wh => wh.Email == request.Email))
                throw new ApiException(EApiException.EmailAlreadyExists);

            if (await _repository.Exists(wh => wh.Document == request.Document))
                throw new ApiException(EApiException.EmployeeAlreadyExists);

            string salt = _authenticationService.GenereateSalt();
            string password = _authenticationService.HashPassword(request.Document, salt);

            User restaurantUser =
                await _userRepository.Find(wh => wh.Id == _authenticationService.GetUserIdFromToken(), query => query.Include(i => i.Restaurant));

            User user = new()
            {
                ProfileId = SecurityProfile.RESTAURANT_ATENDANT_ID,
                Email = request.Email,
                Password = password,
                IsFirstAccess = true,
                IsExpired = false,

                Employee = new()
                {
                    RestaurantId = restaurantUser.Restaurant.Id,
                    Name = request.Name,
                    Document = request.Document,
                    Job = request.Job,
                    Phone = Phone.RemoveMask(request.Phone),
                }
            };

            await _userRepository.Create(user);
            return user.Employee.Id;
        }

        public async Task<Guid> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await ValidateEmployee(request.Id);

            employee.Name = request.Name;
            employee.Document = request.Document;
            employee.Phone = request.Phone;
            employee.Job = request.Job;

            await _repository.Update(employee);
            return employee.Id;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await ValidateEmployee(request.Id);

            await _repository.Delete(employee);

            return Unit.Value;
        }

        private async Task<Employee> ValidateEmployee(Guid id)
        {
            Employee employee = await _repository.Get(id);

            if (employee is null)
                throw new ApiException(EApiException.EmployeeNotFound);

            return employee;
        }
    }
}
