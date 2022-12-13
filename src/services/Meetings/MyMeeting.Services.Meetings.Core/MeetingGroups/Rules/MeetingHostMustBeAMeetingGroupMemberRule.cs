using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Rules;

public class MeetingHostMustBeAMeetingGroupMemberRule : IBusinessRule
{
    private readonly MemberId _creatorId;

    private readonly List<MemberId> _hostsMembersIds;

    private readonly List<MeetingGroupMember> _members;

    public MeetingHostMustBeAMeetingGroupMemberRule(
        MemberId creatorId,
        List<MemberId> hostsMembersIds,
        List<MeetingGroupMember> members)
    {
        _creatorId = creatorId;
        _hostsMembersIds = hostsMembersIds;
        _members = members;
    }

    public bool IsBroken()
    {
        var memberIds = _members.Select(x => x.MemberId).ToList();
        if (!_hostsMembersIds.Any() && !memberIds.Contains(_creatorId))
        {
            return true;
        }

        return _hostsMembersIds.Any() && _hostsMembersIds.Except(memberIds).Any();
    }

    public string Message => "Meeting host must be a meeting group member";
}
