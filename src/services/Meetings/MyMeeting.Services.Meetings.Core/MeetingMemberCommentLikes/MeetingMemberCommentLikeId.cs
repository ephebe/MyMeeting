using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingMemberCommentLikes;

public record MeetingMemberCommentLikeId : AggregateId
{
    public MeetingMemberCommentLikeId(Guid value) : base(value)
    {
        Guard.Against.Null(value, nameof(value));
    }
}
