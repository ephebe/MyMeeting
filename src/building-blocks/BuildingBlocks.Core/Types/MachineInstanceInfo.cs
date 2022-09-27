using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Types;

public record MachineInstanceInfo : IMachineInstanceInfo
{
    public MachineInstanceInfo(Guid clientId, string clientGroup)
    {
        Guard.Against.NullOrEmpty(clientGroup, nameof(clientGroup));

        ClientId = clientId;
        ClientGroup = clientGroup;
    }

    public Guid ClientId { get; }
    public string ClientGroup { get; }

    internal static MachineInstanceInfo New() => new(Guid.NewGuid(), AppDomain.CurrentDomain.FriendlyName);
}
