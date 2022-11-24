using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Rules;

public class MeetingGroupMemberCannotBeAddedTwiceRule : IBusinessRule
{
    private readonly List<MeetingGroupMember> _members;

    private readonly MemberId _memberId;

    public MeetingGroupMemberCannotBeAddedTwiceRule(List<MeetingGroupMember> members, MemberId memberId)
    {
        _members = members;
        _memberId = memberId;
    }

    public bool IsBroken() => this._members.SingleOrDefault(x => x.IsMember(_memberId)) != null;

    public string Message => "Member cannot be added twice to the same group";
}
