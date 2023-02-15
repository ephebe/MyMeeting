using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Payments.Core.Payers;

public record PayerId : AggregateId
{
    public PayerId(Guid value) : base(value)
    {
        Guard.Against.NullOrEmpty(value, nameof(value));
    }
}
