using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MyMeeting.Services.UserAccess.Application.Authentication;
using MyMeeting.Services.UserAccess.Core.UserRegistrations;
using MyMeeting.Services.UserAccess.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.UserRegistrations.RegisterNewUser;

internal class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand, Guid>
{
    private readonly IRepository<UserRegistration, UserRegistrationId> _userRegistrationRepository;
    private readonly IUsersCounter _usersCounter;

    public RegisterNewUserCommandHandler(
        IRepository<UserRegistration, UserRegistrationId> userRegistrationRepository,
        IUsersCounter usersCounter)
    {
        _userRegistrationRepository = userRegistrationRepository;
        _usersCounter = usersCounter;
    }

    public async Task<Guid> Handle(RegisterNewUserCommand command, CancellationToken cancellationToken)
    {
        var password = PasswordManager.HashPassword(command.Password);

        var userRegistration = UserRegistration.RegisterNewUser(
            command.Login,
            password,
            command.Email,
            command.FirstName,
            command.LastName,
            _usersCounter,
            command.ConfirmLink);

        await _userRegistrationRepository.AddAsync(userRegistration);

        return userRegistration.Id.Value;
    }
}