using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Persistence.EfCore;

public interface IConnectionFactory : IDisposable
{
    IDbConnection GetOrCreateConnection();

    string GetConnectionString();
}
