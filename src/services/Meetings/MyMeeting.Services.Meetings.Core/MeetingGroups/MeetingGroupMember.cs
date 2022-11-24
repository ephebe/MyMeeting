using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups;

public class MeetingGroupMember : Entity
{
    internal MeetingGroupId MeetingGroupId { get; private set; }

    internal MemberId MemberId { get; private set; }

    private MeetingGroupMemberRole _role;

    internal DateTime JoinedDate { get; private set; }

    private bool _isActive;

    private DateTime? _leaveDate;

    private MeetingGroupMember()
    {
        // Only for EF.
    }

    private MeetingGroupMember(
        MeetingGroupId meetingGroupId,
        MemberId memberId,
        MeetingGroupMemberRole role)
    {
        this.MeetingGroupId = meetingGroupId;
        this.MemberId = memberId;
        this._role = role;
        this.JoinedDate = SystemClock.Now;
        this._isActive = true;

        
    }

    internal static MeetingGroupMember CreateNew(
        MeetingGroupId meetingGroupId,
        MemberId memberId,
        MeetingGroupMemberRole role)
    {
        return new MeetingGroupMember(meetingGroupId, memberId, role);
    }

    internal void Leave()
    {
        _isActive = false;
        _leaveDate = SystemClock.Now;
    }

    internal bool IsMember(MemberId memberId)
    {
        return this._isActive && this.MemberId == memberId;
    }

    internal bool IsOrganizer(MemberId memberId)
    {
        return this.IsMember(memberId) && _role == MeetingGroupMemberRole.Organizer;
    }
}
