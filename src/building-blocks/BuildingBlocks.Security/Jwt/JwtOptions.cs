using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Jwt;

public class JwtOptions
{
    public string? Algorithm { get; set; }
    public string? Issuer { get; set; }
    public string SecretKey { get; set; } = null!;
    public string? Audience { get; set; }
    public double TokenLifeTimeSecond { get; set; }
}
