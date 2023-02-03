using BuildingBlocks.Abstractions.CQRS.Commands;
using MyMeeting.Services.Identity.Core.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Tokens.GenerateJwtToken;

public class GenerateJwtTokenCommand : ICommand<string>
{
    public GenerateJwtTokenCommand(ApplicationUser user,string refreshToken) 
    {
        this.User = user;
        this.RefreshToken = refreshToken;
    }

    public ApplicationUser User { get; }
    public string RefreshToken { get; }
}
