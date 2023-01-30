using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Core.MeetingGroups.Events;
using MyMeeting.Services.Meetings.Core.MeetingGroups.Rules;
using MyMeeting.Services.Meetings.Core.Meetings;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups;

public class MeetingGroup : Aggregate<MeetingGroupId>
{
    private string _name;

    private string _description;

    private MeetingGroupLocation _location;

    private MemberId _creatorId;

    private List<MeetingGroupMember> _members;

    private DateTime _createDate;

    private DateTime? _paymentDateTo;

    internal static MeetingGroup CreateBasedOnProposal(
        MeetingGroupProposalId meetingGroupProposalId,
        string name,
        string description,
        MeetingGroupLocation location,
        MemberId creatorId)
    {
        return new MeetingGroup(meetingGroupProposalId, name, description, location, creatorId);
    }

    private MeetingGroup()
    {
        // Only for EF.
    }

    private MeetingGroup(MeetingGroupProposalId meetingGroupProposalId, string name, string description, MeetingGroupLocation location, MemberId creatorId)
    {
        this.Id = new MeetingGroupId(meetingGroupProposalId.Value);
        this._name = name;
        this._description = description;
        this._creatorId = creatorId;
        this._location = location;
        this._createDate = SystemClock.Now;

        this.AddDomainEvents(new MeetingGroupCreatedDomainEvent(this.Id, creatorId));

        this._members = new List<MeetingGroupMember>();
        this._members.Add(MeetingGroupMember.CreateNew(this.Id, this._creatorId, MeetingGroupMemberRole.Organizer));
    }

    public void EditGeneralAttributes(string name, string description, MeetingGroupLocation location)
    {
        this._name = name;
        this._description = description;
        this._location = location;
    }

    public void JoinToGroupMember(MemberId memberId)
    {
        this.CheckRule(new MeetingGroupMemberCannotBeAddedTwiceRule(_members, memberId));

        var member = MeetingGroupMember.CreateNew(this.Id, memberId, MeetingGroupMemberRole.Member);
        this._members.Add(member);

        this.AddDomainEvents(member.NewMeetingGroupMemberJoinedDomainEvent);
    }

    public void LeaveGroup(MemberId memberId)
    {
        this.CheckRule(new NotActualGroupMemberCannotLeaveGroupRule(_members, memberId));

        var member = this._members.Single(x => x.IsMember(memberId));

        member.Leave();

        this.AddDomainEvents(member.MeetingGroupMemberLeftGroupDomainEvent);
    }

    public void SetExpirationDate(DateTime dateTo)
    {
        _paymentDateTo = dateTo;

        this.AddDomainEvents(new MeetingGroupPaymentInfoUpdatedDomainEvent(this.Id, _paymentDateTo.Value));
    }

    public Meeting CreateMeeting(
        string title,
        MeetingTerm term,
        string description,
        MeetingLocation location,
        int? attendeesLimit,
        int guestsLimit,
        Term rsvpTerm,
        MoneyValue eventFee,
        List<MemberId> hostsMembersIds,
        MemberId creatorId)
    {
        this.CheckRule(new MeetingCanBeOrganizedOnlyByPayedGroupRule(_paymentDateTo));

        this.CheckRule(new MeetingHostMustBeAMeetingGroupMemberRule(creatorId, hostsMembersIds, _members));

        return Meeting.CreateNew(
            this.Id,
            title,
            term,
            description,
            location,
            MeetingLimits.Create(attendeesLimit, guestsLimit),
            rsvpTerm,
            eventFee,
            hostsMembersIds,
            creatorId);
    }

    internal bool IsMemberOfGroup(MemberId attendeeId)
    {
        return _members.Any(x => x.IsMember(attendeeId));
    }

    internal bool IsOrganizer(MemberId memberId)
    {
        return _members.Any(x => x.IsOrganizer(memberId));
    }
}
