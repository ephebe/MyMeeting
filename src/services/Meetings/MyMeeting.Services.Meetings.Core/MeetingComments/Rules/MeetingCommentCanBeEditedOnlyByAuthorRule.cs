using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Rules;

public class MeetingCommentCanBeEditedOnlyByAuthorRule : IBusinessRule
{
    private readonly MemberId _authorId;
    private readonly MemberId _editorId;

    public MeetingCommentCanBeEditedOnlyByAuthorRule(MemberId authorId, MemberId editorId)
    {
        _authorId = authorId;
        _editorId = editorId;
    }

    public bool IsBroken() => _editorId != _authorId;

    public string Message => "Only the author of a comment can edit it.";
}
