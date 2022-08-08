using BuildingBlocks.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Messaging;

public record Message : IMessage
{
    public Guid MessageId => Guid.NewGuid();
    public DateTime Created { get; } = DateTime.Now;
}
