﻿using BuildingBlocks.Core.Domain;
using MyMeeting.Services.Administration.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals;

public class MeetingGroupProposalDecision : ValueObject
{
    private MeetingGroupProposalDecision(DateTime? date, UserId userId, string code, string rejectReason)
    {
        this.Date = date;
        this.UserId = userId;
        this.Code = code;
        this.RejectReason = rejectReason;
    }

    public DateTime? Date { get; }

    public UserId UserId { get; }

    public string Code { get; }

    public string RejectReason { get; }

    internal static MeetingGroupProposalDecision NoDecision =>
        new MeetingGroupProposalDecision(null, null, null, null);

    private bool IsAccepted => this.Code == "Accept";

    private bool IsRejected => this.Code == "Reject";

    internal static MeetingGroupProposalDecision AcceptDecision(DateTime date, UserId userId)
    {
        return new MeetingGroupProposalDecision(date, userId, "Accept", null);
    }

    internal static MeetingGroupProposalDecision RejectDecision(DateTime date, UserId userId, string rejectReason)
    {
        return new MeetingGroupProposalDecision(date, userId, "Reject", rejectReason);
    }

    internal MeetingGroupProposalStatus GetStatusForDecision()
    {
        if (this.IsAccepted)
        {
            return MeetingGroupProposalStatus.Verified;
        }

        if (this.IsRejected)
        {
            return MeetingGroupProposalStatus.Create("Rejected");
        }

        return MeetingGroupProposalStatus.ToVerify;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return UserId;
        yield return Code;
        yield return RejectReason;
        yield return Date;
    }
}
