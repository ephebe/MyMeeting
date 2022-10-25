using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals;

public record MeetingGroupProposalId : AggregateId
{
    public MeetingGroupProposalId(Guid value)
            : base(value)
    {
    }
}
