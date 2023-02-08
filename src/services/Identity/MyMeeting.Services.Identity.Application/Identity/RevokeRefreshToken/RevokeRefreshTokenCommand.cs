using BuildingBlocks.Abstractions.CQRS.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Identity.RevokeRefreshToken;

public class RevokeRefreshTokenCommand : ICommand<Unit>
{
    public RevokeRefreshTokenCommand(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    public string RefreshToken { get; }
}
