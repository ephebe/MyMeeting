using BuildingBlocks.Core.Domain;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals.Events;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals.Rule;
using MyMeeting.Services.Administration.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals;

public class MeetingGroupProposal : Aggregate<MeetingGroupProposalId>
{
    private string _name;

    private string _description;

    private MeetingGroupLocation _location;

    private DateTime _proposalDate;

    private UserId _proposalUserId;

    private MeetingGroupProposalStatus _status;

    private MeetingGroupProposalDecision _decision;

    private MeetingGroupProposal(
        MeetingGroupProposalId id,
        string name,
        string description,
        MeetingGroupLocation location,
        UserId proposalUserId,
        DateTime proposalDate)
    {
        Id = id;
        _name = name;
        _description = description;
        _location = location;
        _proposalUserId = proposalUserId;
        _proposalDate = proposalDate;

        _status = MeetingGroupProposalStatus.ToVerify;
        _decision = MeetingGroupProposalDecision.NoDecision;

        this.AddDomainEvents(new MeetingGroupProposalVerificationRequestedDomainEvent(this.Id));
    }

    private MeetingGroupProposal()
    {
        _decision = MeetingGroupProposalDecision.NoDecision;
    }

    public MeetingGroupProposalId Id { get; private set; }

    public void Accept(UserId userId)
    {
        this.CheckRule(new MeetingGroupProposalCanBeVerifiedOnceRule(_decision));

        _decision = MeetingGroupProposalDecision.AcceptDecision(DateTime.UtcNow, userId);

        _status = _decision.GetStatusForDecision();

        this.AddDomainEvents(new MeetingGroupProposalAcceptedDomainEvent(this.Id));
    }

    public void Reject(UserId userId, string rejectReason)
    {
        this.CheckRule(new MeetingGroupProposalCanBeVerifiedOnceRule(_decision));
        this.CheckRule(new MeetingGroupProposalRejectionMustHaveAReasonRule(rejectReason));

        _decision = MeetingGroupProposalDecision.RejectDecision(DateTime.UtcNow, userId, rejectReason);

        _status = _decision.GetStatusForDecision();

        this.AddDomainEvents(new MeetingGroupProposalRejectedDomainEvent(this.Id));
    }

    public static MeetingGroupProposal CreateToVerify(
        Guid meetingGroupProposalId,
        string name,
        string description,
        MeetingGroupLocation location,
        UserId proposalUserId,
        DateTime proposalDate)
    {
        var meetingGroupProposal = new MeetingGroupProposal(
            new MeetingGroupProposalId(meetingGroupProposalId),
            name,
            description,
            location,
            proposalUserId,
            proposalDate);

        return meetingGroupProposal;
    }
}
