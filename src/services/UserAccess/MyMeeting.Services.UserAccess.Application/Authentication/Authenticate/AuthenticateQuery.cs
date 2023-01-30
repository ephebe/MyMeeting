using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.Authentication.Authenticate;

public record AuthenticateQuery : IQuery<AuthenticationResult>
{
    public AuthenticateQuery(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public string Login { get; }

    public string Password { get; }
}
