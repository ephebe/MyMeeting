using BuildingBlocks.Abstractions.Web;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Members;

public class MemberContext : IMemberContext
{
    private readonly IExecutionContextAccessor _executionContextAccessor;

    public MemberContext(IExecutionContextAccessor executionContextAccessor)
    {
        this._executionContextAccessor = executionContextAccessor;
    }

    public MemberId MemberId => new MemberId(_executionContextAccessor.UserId);
}
