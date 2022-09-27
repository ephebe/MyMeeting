using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Types;

public interface IMachineInstanceInfo
{
    string ClientGroup { get; }
    Guid ClientId { get; }
}
