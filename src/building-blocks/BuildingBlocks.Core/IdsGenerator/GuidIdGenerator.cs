using BuildingBlocks.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.IdsGenerator;

public class GuidIdGenerator : IIdGenerator<Guid>
{
    public Guid New()
    {
        return Guid.NewGuid();
    }
}
