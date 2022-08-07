using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.CQRS.Commands;

public interface IInternalCommand : ICommand
{
    Guid Id { get; }
    DateTime OccurredOn { get; }
    string Type { get; }
}
