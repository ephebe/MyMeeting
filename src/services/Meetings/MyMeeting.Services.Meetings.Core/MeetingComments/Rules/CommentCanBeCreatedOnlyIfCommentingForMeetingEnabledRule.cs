using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Rules;

public class CommentCanBeCreatedOnlyIfCommentingForMeetingEnabledRule : IBusinessRule
{
    private readonly MeetingCommentingConfiguration _meetingCommentingConfiguration;

    public CommentCanBeCreatedOnlyIfCommentingForMeetingEnabledRule(MeetingCommentingConfiguration meetingCommentingConfiguration)
    {
        _meetingCommentingConfiguration = meetingCommentingConfiguration;
    }

    public bool IsBroken() => !_meetingCommentingConfiguration.GetIsCommentingEnabled();

    public string Message => "Commenting for meeting is disabled.";
}
