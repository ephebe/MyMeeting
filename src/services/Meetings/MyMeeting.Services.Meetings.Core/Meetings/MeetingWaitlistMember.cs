using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class MeetingWaitlistMember : Entity
{
    internal MemberId MemberId { get; private set; }

    internal MeetingId MeetingId { get; private set; }

    internal DateTime SignUpDate { get; private set; }

    private bool _isSignedOff;

    private DateTime? _signOffDate;

    private bool _isMovedToAttendees;

    private DateTime? _movedToAttendeesDate;

    private MeetingWaitlistMember()
    {
    }

    private MeetingWaitlistMember(MeetingId meetingId, MemberId memberId)
    {
        this.MemberId = memberId;
        this.MeetingId = meetingId;
        this.SignUpDate = SystemClock.Now;
        _isMovedToAttendees = false;

        this.AddDomainEvent(new MeetingWaitlistMemberAddedDomainEvent(this.MeetingId, this.MemberId));
    }

    internal static MeetingWaitlistMember CreateNew(MeetingId meetingId, MemberId memberId)
    {
        return new MeetingWaitlistMember(meetingId, memberId);
    }

    internal void MarkIsMovedToAttendees()
    {
        _isMovedToAttendees = true;
        _movedToAttendeesDate = SystemClock.Now;
    }

    internal bool IsActiveOnWaitList(MemberId memberId)
    {
        return this.MemberId == memberId && this.IsActive();
    }

    internal bool IsActive()
    {
        return !_isSignedOff && !_isMovedToAttendees;
    }

    internal void SignOff()
    {
        _isSignedOff = true;
        _signOffDate = SystemClock.Now;

        this.AddDomainEvents(new MemberSignedOffFromMeetingWaitlistDomainEvent(this.MeetingId, this.MemberId));
    }
}
