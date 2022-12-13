using MyMeeting.Services.Meetings.Core.MeetingGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Members;

public class MeetingGroupMemberData
{
    public MeetingGroupId MeetingGroupId { get; }

    public MemberId MemberId { get; }

    public MeetingGroupMemberData(MeetingGroupId meetingGroupId, MemberId memberId)
    {
        MemberId = memberId;
        MeetingGroupId = meetingGroupId;
    }
}
