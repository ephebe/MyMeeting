using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Rules;

public class NotActualGroupMemberCannotLeaveGroupRule : IBusinessRule
{
    private readonly List<MeetingGroupMember> _members;

    private readonly MemberId memberId;

    public NotActualGroupMemberCannotLeaveGroupRule(List<MeetingGroupMember> members, MemberId memberId)
    {
        _members = members;
        this.memberId = memberId;
    }

    public bool IsBroken() => this._members.SingleOrDefault(x => x.IsMember(memberId)) == null;

    public string Message => "Member is not member of this group so he cannot leave it";
}
