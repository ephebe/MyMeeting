using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Jwt;

public interface IJwtService
{
    string GenerateJwtToken(
        string userName,
        string email,
        string userId,
        bool? isVerified = null,
        string? fullName = null,
        string? refreshToken = null,
        IReadOnlyList<Claim>? usersClaims = null,
        IReadOnlyList<string>? rolesClaims = null,
        IReadOnlyList<string>? permissionsClaims = null);

    ClaimsPrincipal? GetPrincipalFromToken(string token);
}
