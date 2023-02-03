using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Tokens.GenerateRefreshToken;

public class GenerateRefreshTokenCommand : ICommand<GenerateRefreshTokenCommandResult>
{
    public Guid UserId { get; init; }
    public string Token { get; init; }
}
