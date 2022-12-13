using BuildingBlocks.Core.Domain;
using MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations.Events;
using MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations.Rules;
using MyMeeting.Services.Meetings.Core.MeetingComments;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Meetings;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations;

public class MeetingCommentingConfiguration : Aggregate<MeetingCommentingConfigurationId>
{
    private MeetingId _meetingId;

    private bool _isCommentingEnabled;

    private MeetingCommentingConfiguration(MeetingId meetingId)
    {
        this.Id = new MeetingCommentingConfigurationId(Guid.NewGuid());
        this._meetingId = meetingId;
        this._isCommentingEnabled = true;

        this.AddDomainEvents(new MeetingCommentingConfigurationCreatedDomainEvent(this._meetingId, this._isCommentingEnabled));
    }

    private MeetingCommentingConfiguration()
    {
        // Only for EF.
    }

    public void EnableCommenting(MemberId enablingMemberId, MeetingGroup meetingGroup)
    {
        CheckRule(new MeetingCommentingCanBeEnabledOnlyByGroupOrganizerRule(enablingMemberId, meetingGroup));

        if (!this._isCommentingEnabled)
        {
            this._isCommentingEnabled = true;
            AddDomainEvents(new MeetingCommentingEnabledDomainEvent(this._meetingId));
        }
    }

    public void DisableCommenting(MemberId disablingMemberId, MeetingGroup meetingGroup)
    {
        CheckRule(new MeetingCommentingCanBeDisabledOnlyByGroupOrganizerRule(disablingMemberId, meetingGroup));

        if (this._isCommentingEnabled)
        {
            this._isCommentingEnabled = false;
            AddDomainEvents(new MeetingCommentingDisabledDomainEvent(this._meetingId));
        }
    }

    public bool GetIsCommentingEnabled() => _isCommentingEnabled;

    internal static MeetingCommentingConfiguration Create(MeetingId meetingId)
        => new MeetingCommentingConfiguration(meetingId);
}
