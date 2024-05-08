using MediatR;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.User;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Exceptions;
using WasteWiseEats_API.Domain.Exceptions.Enums;
using WasteWiseEats_API.Domain.Extensions;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Interfaces.Services;
using WasteWiseEats_API.Domain.Models.Authentications;

namespace WasteWiseEats_API.Domain.CommandHandlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, Guid>,
                                      IRequestHandler<UserAuthenticationCommand, Authenticated<AuthenticatedUser>>

    {
        private readonly IUserRepository _repository;
        private readonly ISecurityProfileRepository _securityProfileRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserCommandHandler(IUserRepository repository, IAuthenticationService authenticationService, ISecurityProfileRepository securityProfileRepository)
        {
            _repository = repository;
            _authenticationService = authenticationService;
            _securityProfileRepository = securityProfileRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.Exists(wh => wh.Email == request.Email))
                throw new ApiException(EApiException.EmailAlreadyExists);

            string salt = _authenticationService.GenereateSalt();
            string password = _authenticationService.HashPassword(request.Password, salt);

            if (!await _securityProfileRepository.Exists(wh => wh.Id == request.ProfileId) || request.ProfileId == SecurityProfile.RESTAURANT_ATENDANT_ID)
                throw new ApiException(EApiException.InvalidSecurityProfile);

            User user = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = password,
                Salt = salt,
                ProfileId = request.ProfileId,
                IsFirstAccess = true,
                IsExpired = false
            };

            await _repository.Create(user);
            return user.Id;
        }

        public async Task<Authenticated<AuthenticatedUser>> Handle(UserAuthenticationCommand request, CancellationToken cancellationToken)
        {
            User user = await _repository.Find(wh => wh.Email == request.Login, query => query
                                         .Include(i => i.Profile)
                                            .ThenInclude(t => t.Roles));

            if (user.IsExpired)
                throw new ApiException(EApiException.InactiveUser);

            string hashedPassword = _authenticationService.HashPassword(request.Password, user.Salt);

            if (user is null || user.Password != hashedPassword)
                throw new ApiException(EApiException.AuthenticationFailure);

            IEnumerable<string> roles =
                user.Profile.Roles.Select(profileRole => profileRole.Role.GetDescription());

            if (user.IsFirstAccess)
                user.IsFirstAccess = false;

            user.LastLogin = DateTime.Now;

            await _repository.Update(user);

            return _authenticationService.Authenticate(new AuthenticatedUser
            {
                Id = user.Id,
                Profile = user.Profile.Name,
                Name = user.Name,
                Roles = roles
            });
        }
    }
}
