using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Rules;

public class CommentTextMustBeProvidedRule : IBusinessRule
{
    private readonly string _comment;

    public CommentTextMustBeProvidedRule(string comment)
    {
        _comment = comment;
    }

    public bool IsBroken() => string.IsNullOrEmpty(_comment);

    public string Message => "Comment text must be provided.";
}
