using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations;
using MyMeeting.Services.Meetings.Core.MeetingComments;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.MeetingGroups.Events;
using MyMeeting.Services.Meetings.Core.Meetings.Events;
using MyMeeting.Services.Meetings.Core.Meetings.Rules;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class Meeting : Aggregate<MeetingId>
{
    private MeetingGroupId _meetingGroupId;

    private string _title;

    private MeetingTerm _term;

    private string _description;

    private MeetingLocation _location;

    private List<MeetingAttendee> _attendees;

    private List<MeetingNotAttendee> _notAttendees;

    private List<MeetingWaitlistMember> _waitlistMembers;

    private MeetingLimits _meetingLimits;

    private Term _rsvpTerm;

    private MoneyValue _eventFee;

    private MemberId _creatorId;

    private DateTime _createDate;

    private MemberId _changeMemberId;

    private DateTime? _changeDate;

    private DateTime? _cancelDate;

    private MemberId _cancelMemberId;

    private bool _isCanceled;

    private Meeting()
    {
        _attendees = new List<MeetingAttendee>();
        _notAttendees = new List<MeetingNotAttendee>();
        _waitlistMembers = new List<MeetingWaitlistMember>();
    }

    internal static Meeting CreateNew(
        MeetingGroupId meetingGroupId,
        string title,
        MeetingTerm term,
        string description,
        MeetingLocation location,
        MeetingLimits meetingLimits,
        Term rsvpTerm,
        MoneyValue eventFee,
        List<MemberId> hostsMembersIds,
        MemberId creatorId)
    {
        return new Meeting(
            meetingGroupId,
            title,
            term,
            description,
            location,
            meetingLimits,
            rsvpTerm,
            eventFee,
            hostsMembersIds,
            creatorId);
    }

    private Meeting(
        MeetingGroupId meetingGroupId,
        string title,
        MeetingTerm term,
        string description,
        MeetingLocation location,
        MeetingLimits meetingLimits,
        Term rsvpTerm,
        MoneyValue eventFee,
        List<MemberId> hostsMembersIds,
        MemberId creatorId)
    {
        Id = new MeetingId(Guid.NewGuid());
        _meetingGroupId = meetingGroupId;
        _title = title;
        _term = term;
        _description = description;
        _location = location;
        _meetingLimits = meetingLimits;

        this.SetRsvpTerm(rsvpTerm, _term);
        _eventFee = eventFee;
        _creatorId = creatorId;
        _createDate = SystemClock.Now;

        _attendees = new List<MeetingAttendee>();
        _notAttendees = new List<MeetingNotAttendee>();
        _waitlistMembers = new List<MeetingWaitlistMember>();

        this.AddDomainEvents(new MeetingCreatedDomainEvent(this.Id));
        var rsvpDate = SystemClock.Now;
        if (hostsMembersIds.Any())
        {
            foreach (var hostMemberId in hostsMembersIds)
            {
                var attendee = MeetingAttendee.CreateNew(this.Id, hostMemberId, rsvpDate, MeetingAttendeeRole.Host, 0, MoneyValue.Undefined);
                _attendees.Add(attendee);
                this.AddDomainEvents(attendee.MeetingAttendeeAddedDomainEvent);
            }
        }
        else
        {
            var attendee = MeetingAttendee.CreateNew(this.Id, creatorId, rsvpDate, MeetingAttendeeRole.Host, 0, MoneyValue.Undefined);
            _attendees.Add(attendee);
            this.AddDomainEvents(attendee.MeetingAttendeeAddedDomainEvent);
        }
    }

    public void ChangeMainAttributes(
        string title,
        MeetingTerm term,
        string description,
        MeetingLocation location,
        MeetingLimits meetingLimits,
        Term rsvpTerm,
        MoneyValue eventFee,
        MemberId modifyUserId)
    {
        this.CheckRule(new AttendeesLimitCannotBeChangedToSmallerThanActiveAttendeesRule(
            meetingLimits,
            this.GetAllActiveAttendeesWithGuestsNumber()));

        _title = title;
        _term = term;
        _description = description;
        _location = location;
        _meetingLimits = meetingLimits;
        this.SetRsvpTerm(rsvpTerm, _term);
        _eventFee = eventFee;

        _changeDate = SystemClock.Now;
        _changeMemberId = modifyUserId;
    }

    public void AddAttendee(MeetingGroup meetingGroup, MemberId attendeeId, int guestsNumber)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));

        this.CheckRule(new AttendeeCanBeAddedOnlyInRsvpTermRule(_rsvpTerm));

        this.CheckRule(new MeetingAttendeeMustBeAMemberOfGroupRule(attendeeId, meetingGroup));

        this.CheckRule(new MemberCannotBeAnAttendeeOfMeetingMoreThanOnceRule(attendeeId, _attendees));

        this.CheckRule(new MeetingGuestsNumberIsAboveLimitRule(_meetingLimits.GuestsLimit, guestsNumber));

        this.CheckRule(new MeetingAttendeesNumberIsAboveLimitRule(_meetingLimits.AttendeesLimit, this.GetAllActiveAttendeesWithGuestsNumber(), guestsNumber));

        var notAttendee = this.GetActiveNotAttendee(attendeeId);
        notAttendee?.ChangeDecision();

        MeetingAttendeeAddedDomainEvent meetingAttendeeAddedDomainEvent = null;
        var attendee = MeetingAttendee.CreateNew(
            this.Id,
            attendeeId,
            SystemClock.Now,
            MeetingAttendeeRole.Attendee,
            guestsNumber,
            _eventFee);

        _attendees.Add(attendee);

        this.AddDomainEvents(attendee.MeetingAttendeeAddedDomainEvent);
    }

    public void AddNotAttendee(MemberId memberId)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));

        this.CheckRule(new MemberCannotBeNotAttendeeTwiceRule(_notAttendees, memberId));

        _notAttendees.Add(MeetingNotAttendee.CreateNew(this.Id, memberId));

        var attendee = this.GetActiveAttendee(memberId);

        if (attendee != null) 
        {
            attendee.ChangeDecision();
            this.AddDomainEvents(attendee.MeetingAttendeeChangedDecisionDomainEvent);
        }

        var nextWaitlistMember = _waitlistMembers
            .Where(x => x.IsActive())
            .OrderBy(x => x.SignUpDate)
            .FirstOrDefault();

        if (nextWaitlistMember != null)
        {
            _attendees.Add(MeetingAttendee.CreateNew(
                this.Id,
                nextWaitlistMember.MemberId,
                nextWaitlistMember.SignUpDate,
                MeetingAttendeeRole.Attendee,
                0,
                this._eventFee));
            nextWaitlistMember.MarkIsMovedToAttendees();
        }
    }

    public void ChangeNotAttendeeDecision(MemberId memberId)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));

        this.CheckRule(new NotActiveNotAttendeeCannotChangeDecisionRule(_notAttendees, memberId));

        var notAttendee = _notAttendees.Single(x => x.IsActiveNotAttendee(memberId));

        notAttendee.ChangeDecision();
    }

    public void SignUpMemberToWaitlist(MeetingGroup meetingGroup, MemberId memberId)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));

        this.CheckRule(new AttendeeCanBeAddedOnlyInRsvpTermRule(_rsvpTerm));

        this.CheckRule(new MemberOnWaitlistMustBeAMemberOfGroupRule(meetingGroup, memberId, _attendees));

        this.CheckRule(new MemberCannotBeMoreThanOnceOnMeetingWaitlistRule(_waitlistMembers, memberId));

        _waitlistMembers.Add(MeetingWaitlistMember.CreateNew(this.Id, memberId));
    }

    public void SignOffMemberFromWaitlist(MemberId memberId)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));

        this.CheckRule(new NotActiveMemberOfWaitlistCannotBeSignedOffRule(_waitlistMembers, memberId));

        var memberOnWaitlist = this.GetActiveMemberOnWaitlist(memberId);

        memberOnWaitlist.SignOff();
    }

    public void SetHostRole(MeetingGroup meetingGroup, MemberId settingMemberId, MemberId newOrganizerId)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));

        this.CheckRule(new OnlyMeetingOrGroupOrganizerCanSetMeetingMemberRolesRule(settingMemberId, meetingGroup, _attendees));

        this.CheckRule(new OnlyMeetingAttendeeCanHaveChangedRoleRule(_attendees, newOrganizerId));

        var attendee = this.GetActiveAttendee(newOrganizerId);

        attendee.SetAsHost(out NewMeetingHostSetDomainEvent newMeetingHostSetDomainEvent);
        this.AddDomainEvents(newMeetingHostSetDomainEvent);
    }

    public void SetAttendeeRole(MeetingGroup meetingGroup, MemberId settingMemberId, MemberId newOrganizerId)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));

        this.CheckRule(new OnlyMeetingOrGroupOrganizerCanSetMeetingMemberRolesRule(settingMemberId, meetingGroup, _attendees));

        this.CheckRule(new OnlyMeetingAttendeeCanHaveChangedRoleRule(_attendees, newOrganizerId));

        var attendee = this.GetActiveAttendee(newOrganizerId);

        attendee.SetAsAttendee();

        var meetingHostNumber = _attendees.Count(x => x.IsActiveHost());

        this.CheckRule(new MeetingMustHaveAtLeastOneHostRule(meetingHostNumber));
    }

    public MeetingGroupId GetMeetingGroupId() => _meetingGroupId;

    public void Cancel(MemberId cancelMemberId)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));

        if (!_isCanceled)
        {
            _isCanceled = true;
            _cancelDate = SystemClock.Now;
            _cancelMemberId = cancelMemberId;

            this.AddDomainEvents(new MeetingCanceledDomainEvent(this.Id, _cancelMemberId, _cancelDate.Value));
        }
    }

    public void RemoveAttendee(MemberId attendeeId, MemberId removingPersonId, string reason)
    {
        this.CheckRule(new MeetingCannotBeChangedAfterStartRule(_term));
        this.CheckRule(new OnlyActiveAttendeeCanBeRemovedFromMeetingRule(_attendees, attendeeId));

        var attendee = this.GetActiveAttendee(attendeeId);

        attendee.Remove(removingPersonId, reason);
    }

    public void MarkAttendeeFeeAsPayed(MemberId memberId)
    {
        var attendee = GetActiveAttendee(memberId);

        attendee.MarkFeeAsPayed();
    }

    public MeetingComment AddComment(MemberId authorId, string comment, MeetingGroup meetingGroup, MeetingCommentingConfiguration meetingCommentingConfiguration)
        => MeetingComment.Create(
            this.Id,
            authorId,
            comment,
            meetingGroup,
            meetingCommentingConfiguration);

    public MeetingCommentingConfiguration CreateCommentingConfiguration()
    {
        return MeetingCommentingConfiguration.Create(this.Id);
    }

    private MeetingWaitlistMember GetActiveMemberOnWaitlist(MemberId memberId)
    {
        return _waitlistMembers.SingleOrDefault(x => x.IsActiveOnWaitList(memberId));
    }

    private MeetingAttendee GetActiveAttendee(MemberId attendeeId)
    {
        return _attendees.SingleOrDefault(x => x.IsActiveAttendee(attendeeId));
    }

    private MeetingNotAttendee GetActiveNotAttendee(MemberId memberId)
    {
        return _notAttendees.SingleOrDefault(x => x.IsActiveNotAttendee(memberId));
    }

    private int GetAllActiveAttendeesWithGuestsNumber()
    {
        return _attendees.Where(x => x.IsActive()).Sum(x => x.GetAttendeeWithGuestsNumber());
    }

    private void SetRsvpTerm(Term rsvpTerm, MeetingTerm meetingTerm)
    {
        if (!rsvpTerm.EndDate.HasValue || rsvpTerm.EndDate > meetingTerm.StartDate)
        {
            _rsvpTerm = Term.CreateNewBetweenDates(rsvpTerm.StartDate, meetingTerm.StartDate);
        }
        else
        {
            _rsvpTerm = rsvpTerm;
        }
    }
}
