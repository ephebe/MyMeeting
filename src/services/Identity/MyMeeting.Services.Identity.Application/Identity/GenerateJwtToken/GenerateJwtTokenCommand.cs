using BuildingBlocks.Abstractions.CQRS.Commands;
using MyMeeting.Services.Identity.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Identity.GenerateJwtToken;

public class GenerateJwtTokenCommand : ICommand<string>
{
    public GenerateJwtTokenCommand(ApplicationUser user, string refreshToken)
    {
        User = user;
        RefreshToken = refreshToken;
    }

    public ApplicationUser User { get; }
    public string RefreshToken { get; }
}
