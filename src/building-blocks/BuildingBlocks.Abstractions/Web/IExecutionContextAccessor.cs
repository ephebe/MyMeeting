using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Web;

public interface IExecutionContextAccessor
{
    Guid UserId { get; }

    Guid CorrelationId { get; }

    bool IsAvailable { get; }
}
