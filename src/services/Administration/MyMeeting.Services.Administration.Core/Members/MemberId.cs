using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.Members;

public record MemberId : AggregateId
{
    public MemberId(Guid value) : base(value)
    {
        Guard.Against.Null(value, nameof(value));
    }

    public static implicit operator Guid(MemberId id) => id.Value;

    public static implicit operator MemberId(Guid id) => new(id);
}
