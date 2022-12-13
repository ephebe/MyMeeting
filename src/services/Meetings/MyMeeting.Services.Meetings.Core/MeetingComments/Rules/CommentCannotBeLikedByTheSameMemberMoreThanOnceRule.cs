using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Rules;

public class CommentCannotBeLikedByTheSameMemberMoreThanOnceRule : IBusinessRule
{
    private readonly int _memberCommentLikesCount;

    public CommentCannotBeLikedByTheSameMemberMoreThanOnceRule(int memberCommentLikesCount)
    {
        _memberCommentLikesCount = memberCommentLikesCount;
    }

    public bool IsBroken() => _memberCommentLikesCount > 0;

    public string Message => "Member cannot like one comment more than once.";
}
