using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations;

public record MeetingCommentingConfigurationId : AggregateId
{
    public MeetingCommentingConfigurationId(Guid value) : base(value)
    {
        Guard.Against.NullOrEmpty(value, nameof(value));
    }
}
