using MyMeeting.Services.Meetings.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core;

public interface IMemberContext
{
    MemberId MemberId { get; }
}
