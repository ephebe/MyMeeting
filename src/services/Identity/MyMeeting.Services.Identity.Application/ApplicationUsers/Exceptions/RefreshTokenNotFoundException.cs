
using BuildingBlocks.Core.Exception.Types;
using MyMeeting.Services.Identity.Core.RefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.ApplicationUsers.Exceptions;

public class RefreshTokenNotFoundException : NotFoundException
{
    public RefreshTokenNotFoundException(RefreshToken? refreshToken) : base("Refresh token not found.")
    {
    }
}
