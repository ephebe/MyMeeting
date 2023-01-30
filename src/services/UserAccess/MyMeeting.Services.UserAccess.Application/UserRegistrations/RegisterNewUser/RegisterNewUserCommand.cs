using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.UserRegistrations.RegisterNewUser;

public class RegisterNewUserCommand : ICommand<Guid>
{
    public RegisterNewUserCommand(
        string login,
        string password,
        string email,
        string firstName,
        string lastName,
        string confirmLink)
    {
        Login = login;
        Password = password;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        ConfirmLink = confirmLink;
    }

    public string Login { get; }

    public string Password { get; }

    public string Email { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string ConfirmLink { get; }
}