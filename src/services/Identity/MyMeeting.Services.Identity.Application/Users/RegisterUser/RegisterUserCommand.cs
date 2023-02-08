using BuildingBlocks.Abstractions.CQRS.Commands;
using MyMeeting.Services.Identity.Application.Identity.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Users.RegisterUser;

public class RegisterUserCommand : ICommand<LoginResponse>
{
}
