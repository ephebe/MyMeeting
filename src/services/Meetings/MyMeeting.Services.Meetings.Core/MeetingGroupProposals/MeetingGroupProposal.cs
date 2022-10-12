using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals.Events;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals.Rules;
using MyMeeting.Services.Meetings.Core.Members;

namespace MyMeeting.Services.Meetings.Core.MeetingGroupProposals;

public class MeetingGroupProposal : Aggregate<MeetingGroupProposalId>
{
    private string _name;

    private string _description;

    private MeetingGroupLocation _location;

    private DateTime _proposalDate;

    private MemberId _proposalUserId;

    private MeetingGroupProposalStatus _status;

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

        AddDomainEvents(new MeetingGroupProposedDomainEvent(Id, _name, _description, proposalUserId, _proposalDate, _location.City, _location.CountryCode));
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
        CheckRule(new MeetingGroupProposalCannotBeAcceptedMoreThanOnceRule(_status));

        _status = MeetingGroupProposalStatus.Accepted;

        AddDomainEvents(new MeetingGroupProposalAcceptedDomainEvent(Id));
    }
}
