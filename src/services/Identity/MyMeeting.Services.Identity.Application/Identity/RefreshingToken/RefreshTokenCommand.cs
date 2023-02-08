using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Identity.RefreshingToken;

public class RefreshTokenCommand : ICommand<RefreshTokenResult>
{
    public RefreshTokenCommand(string accessTokenData, string refreshTokenData)
    {
        RefreshTokenData = refreshTokenData;
        AccessTokenData = accessTokenData;
    }

    public string RefreshTokenData { get; }
    public string AccessTokenData { get; }
}
