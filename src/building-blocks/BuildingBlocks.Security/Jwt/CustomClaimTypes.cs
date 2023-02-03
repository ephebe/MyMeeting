using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Jwt;

public static class CustomClaimTypes
{
    public const string Permission = "permission";
    public const string IpAddress = "ipAddress";
    public const string RefreshToken = "refreshToken";
}
