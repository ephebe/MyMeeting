using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MediatR;
using MyMeeting.Services.UserAccess.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.Users.AddAdminUser;

internal class AddAdminUserCommandHandler : ICommandHandler<AddAdminUserCommand>
{
    private readonly IRepository<User, UserId> _userRepository;

    public AddAdminUserCommandHandler(IRepository<User, UserId> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(AddAdminUserCommand command, CancellationToken cancellationToken)
    {
        var password = PasswordManager.HashPassword(command.Password);

        var user = User.CreateAdmin(
            command.Login,
            password,
            command.Email,
            command.FirstName,
            command.LastName,
            command.Name);

        await _userRepository.AddAsync(user);

        return Unit.Value;
    }
}