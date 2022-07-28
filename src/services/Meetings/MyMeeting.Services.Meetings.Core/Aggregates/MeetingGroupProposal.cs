using BuildingBlocks.Core.Domain;
using MyMeeting.Services.Meetings.Core.Types;
using MyMeeting.Services.Meetings.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Aggregates;

public class MeetingGroupProposal : Aggregate<MeetingGroupProposalId>
{
    public MeetingGroupProposalId Id { get; private set; }

    private string _name;

    private string _description;

    private MeetingGroupLocation _location;

    private DateTime _proposalDate;

    private MemberId _proposalUserId;

    private MeetingGroupProposalStatus _status;

    public MeetingGroup CreateMeetingGroup()
    {
        return MeetingGroup.CreateBasedOnProposal(this.Id, _name, _description, _location, _proposalUserId);
    }

    private MeetingGroupProposal()
    {
        // Only for EF.
    }

    private MeetingGroupProposal(
        string name,
        string description,
        MeetingGroupLocation location,
        MemberId proposalUserId)
    {
        Id = new MeetingGroupProposalId(Guid.NewGuid());
        _name = name;
        _description = description;
        _location = location;
        _proposalUserId = proposalUserId;
        _proposalDate = SystemClock.Now;
        _status = MeetingGroupProposalStatus.InVerification;

        this.AddDomainEvent(new MeetingGroupProposedDomainEvent(this.Id, _name, _description, proposalUserId, _proposalDate, _location.City, _location.CountryCode));
    }

    public static MeetingGroupProposal ProposeNew(
        string name,
        string description,
        MeetingGroupLocation location,
        MemberId proposalMemberId)
    {
        return new MeetingGroupProposal(name, description, location, proposalMemberId);
    }

    public void Accept()
    {
        this.CheckRule(new MeetingGroupProposalCannotBeAcceptedMoreThanOnceRule(_status));

        _status = MeetingGroupProposalStatus.Accepted;

        this.AddDomainEvent(new MeetingGroupProposalAcceptedDomainEvent(this.Id));
    }
}
