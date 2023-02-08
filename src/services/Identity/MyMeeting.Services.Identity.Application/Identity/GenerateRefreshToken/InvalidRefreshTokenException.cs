using BuildingBlocks.Core.Exception.Types;
using MyMeeting.Services.Identity.Core.RefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Identity.GenerateRefreshToken;

public class InvalidRefreshTokenException : BadRequestException
{
    public InvalidRefreshTokenException(RefreshToken? refreshToken) : base($"refresh token {refreshToken?.Token} is invalid!")
    {
    }
}
