using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Core;

public interface IIdGenerator<out TId>
{
    TId New();
}
