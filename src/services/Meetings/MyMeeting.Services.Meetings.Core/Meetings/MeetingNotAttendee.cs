using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using MyMeeting.Services.Meetings.Core.Meetings.Events;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class MeetingNotAttendee : Entity
{
    internal MemberId MemberId { get; private set; }

    internal MeetingId MeetingId { get; private set; }

    private DateTime _decisionDate;

    private bool _decisionChanged;

    private DateTime? _decisionChangeDate;

    internal MeetingNotAttendeeAddedDomainEvent MeetingNotAttendeeAddedDomainEvent
        => new MeetingNotAttendeeAddedDomainEvent(this.MeetingId, this.MemberId);

    internal MeetingNotAttendeeChangedDecisionDomainEvent MeetingNotAttendeeChangedDecisionDomainEvent
        => new MeetingNotAttendeeChangedDecisionDomainEvent(this.MemberId, this.MeetingId);

    private MeetingNotAttendee()
    {
    }

    private MeetingNotAttendee(MeetingId meetingId, MemberId memberId)
    {
        this.MemberId = memberId;
        this.MeetingId = meetingId;
        _decisionDate = DateTime.UtcNow;

        
    }

    internal static MeetingNotAttendee CreateNew(MeetingId meetingId, MemberId memberId)
    {
        return new MeetingNotAttendee(meetingId, memberId);
    }

    internal bool IsActiveNotAttendee(MemberId memberId)
    {
        return !this._decisionChanged && this.MemberId == memberId;
    }

    internal void ChangeDecision()
    {
        _decisionChanged = true;
        _decisionChangeDate = SystemClock.Now;
    }
}
