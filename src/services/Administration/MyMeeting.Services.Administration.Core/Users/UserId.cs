using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.Users;

public record UserId : AggregateId
{
    public UserId(Guid value)
            : base(value)
    {
    }
}
