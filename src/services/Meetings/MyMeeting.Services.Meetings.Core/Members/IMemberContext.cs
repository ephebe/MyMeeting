using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Members;

public interface IMemberContext
{
    MemberId MemberId { get; }
}
