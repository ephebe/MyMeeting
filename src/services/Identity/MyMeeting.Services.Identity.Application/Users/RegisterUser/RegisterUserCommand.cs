using BuildingBlocks.Abstractions.CQRS.Commands;
using MyMeeting.Services.Identity.Application.Identity.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Users.RegisterUser;

public class RegisterUserCommand : ICommand<RegisterUserResult>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string UserName { get; }
    public string Email { get; }
    public string Password { get; }
    public string ConfirmPassword { get; }
    public List<string>? Roles { get; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public RegisterUserCommand(
        string firstName,string lastName,string userName,string email,string password,string confirmPassword, List<string>? roles) 
    {
        FirstName= firstName;
        LastName= lastName;
        UserName= userName;
        Email= email;
        Password= password;
        ConfirmPassword= confirmPassword;
        Roles= roles;
    }
}
