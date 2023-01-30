using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.Users.AddAdminUser;

public class AddAdminUserCommand : ICommand
{
    public AddAdminUserCommand(
            string login,
            string password,
            string firstName,
            string lastName,
            string name,
            string email)
    {
        Login = login;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        Email = email;
    }

    public string Login { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Name { get; }

    public string Email { get; }

    public string Password { get; }
}
