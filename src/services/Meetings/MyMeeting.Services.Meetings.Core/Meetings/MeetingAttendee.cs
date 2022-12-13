using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using MyMeeting.Services.Meetings.Core.MeetingGroups.Events;
using MyMeeting.Services.Meetings.Core.Meetings.Events;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class MeetingAttendee : Entity
{
    internal MemberId AttendeeId { get; private set; }

    internal MeetingId MeetingId { get; private set; }

    private DateTime _decisionDate;

    private MeetingAttendeeRole _role;

    private int _guestsNumber;

    private bool _decisionChanged;

    private DateTime? _decisionChangeDate;

    private DateTime? _removedDate;

    private MemberId _removingMemberId;

    private string _removingReason;

    private bool _isRemoved;

    private MoneyValue _fee;

    private bool _isFeePaid;

    private MeetingAttendee()
    {
    }

    public MeetingAttendeeAddedDomainEvent MeetingAttendeeAddedDomainEvent 
    {
        get 
        {
            return new MeetingAttendeeAddedDomainEvent(
                this.MeetingId,
                this.AttendeeId,
                this._decisionDate,
                this._role.Value,
                this._guestsNumber,
                this._fee.Value,
                this._fee.Currency
            );
        }
    }

    public MeetingAttendeeChangedDecisionDomainEvent MeetingAttendeeChangedDecisionDomainEvent 
    {
        get 
        {
            return new MeetingAttendeeChangedDecisionDomainEvent(this.AttendeeId, this.MeetingId);
        }
    }

    internal static MeetingAttendee CreateNew(
        MeetingId meetingId,
        MemberId attendeeId,
        DateTime decisionDate,
        MeetingAttendeeRole role,
        int guestsNumber,
        MoneyValue eventFee)
    {
        var meetingAttendee = 
            new MeetingAttendee(meetingId, attendeeId, decisionDate, role, guestsNumber, eventFee);

        return meetingAttendee;
    }

    private MeetingAttendee(
        MeetingId meetingId,
        MemberId attendeeId,
        DateTime decisionDate,
        MeetingAttendeeRole role,
        int guestsNumber,
        MoneyValue eventFee)
    {
        this.AttendeeId = attendeeId;
        this.MeetingId = meetingId;
        this._decisionDate = decisionDate;
        this._role = role;
        _guestsNumber = guestsNumber;
        _decisionChanged = false;
        _isFeePaid = false;

        if (eventFee != MoneyValue.Undefined)
        {
            _fee = (1 + guestsNumber) * eventFee;
        }
        else
        {
            _fee = MoneyValue.Undefined;
        }
    }

    internal void ChangeDecision()
    {
        _decisionChanged = true;
        _decisionChangeDate = SystemClock.Now;
    }

    internal bool IsActiveAttendee(MemberId attendeeId)
    {
        return this.AttendeeId == attendeeId && !_decisionChanged;
    }

    internal bool IsActive()
    {
        return !_decisionChangeDate.HasValue && !_isRemoved;
    }

    internal bool IsActiveHost()
    {
        return this.IsActive() && _role == MeetingAttendeeRole.Host;
    }

    internal int GetAttendeeWithGuestsNumber()
    {
        return 1 + _guestsNumber;
    }

    internal void SetAsHost(out NewMeetingHostSetDomainEvent @event)
    {
        _role = MeetingAttendeeRole.Host;

        @event = new NewMeetingHostSetDomainEvent(this.MeetingId, this.AttendeeId);
    }

    internal void SetAsAttendee()
    {
        this.CheckRule(new MemberCannotHaveSetAttendeeRoleMoreThanOnceRule(_role));
        _role = MeetingAttendeeRole.Attendee;

        this.AddDomainEvent(new MemberSetAsAttendeeDomainEvent(this.MeetingId, this.AttendeeId));
    }

    internal void Remove(MemberId removingMemberId, string reason)
    {
        this.CheckRule(new ReasonOfRemovingAttendeeFromMeetingMustBeProvidedRule(reason));

        _isRemoved = true;
        _removedDate = SystemClock.Now;
        _removingReason = reason;
        _removingMemberId = removingMemberId;

        this.AddDomainEvent(new MeetingAttendeeRemovedDomainEvent(this.AttendeeId, this.MeetingId, reason));
    }

    internal void MarkFeeAsPayed()
    {
        _isFeePaid = true;

        this.AddDomainEvent(new MeetingAttendeeFeePaidDomainEvent(this.MeetingId, this.AttendeeId));
    }
}
