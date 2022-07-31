using MyMeeting.Services.Meetings.Core.Aggregates;
using MyMeeting.Services.Meetings.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Repositories;

public interface IMeetingGroupProposalRepository
{
    Task AddAsync(MeetingGroupProposal meetingGroupProposal);

    Task<MeetingGroupProposal> GetByIdAsync(MeetingGroupProposalId meetingGroupProposalId);
}
