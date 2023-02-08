using BuildingBlocks.Abstractions.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Identity.Login;

public class LoginCommand : ICommand<LoginResponse>
{
    public LoginCommand(string userNameOrEmail, string password, bool remember)
    {

    }

    public string UserNameOrEmail { get; }
    public string Password { get; }
    public bool Remember { get; }
}
