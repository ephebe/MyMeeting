using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Identity.GenerateRefreshToken;

public class GenerateRefreshTokenCommandResult
{
    public GenerateRefreshTokenCommandResult(RefreshTokenDto refreshTokenDto)
    {
        RefreshToken = refreshTokenDto;
    }

    public RefreshTokenDto RefreshToken { get; }
}
