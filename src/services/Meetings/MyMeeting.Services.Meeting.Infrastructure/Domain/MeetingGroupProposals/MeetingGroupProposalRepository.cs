using Microsoft.EntityFrameworkCore;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meeting.Infrastructure.Domain.MeetingGroupProposals;

public class MeetingGroupProposalRepository : IMeetingGroupProposalRepository
{
    private readonly MeetingsContext _context;

    internal MeetingGroupProposalRepository(MeetingsContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MeetingGroupProposal meetingGroupProposal)
    {
        await _context.MeetingGroupProposals.AddAsync(meetingGroupProposal);
    }

    public async Task<MeetingGroupProposal> GetByIdAsync(MeetingGroupProposalId meetingGroupProposalId)
    {
        return await _context.MeetingGroupProposals.FirstOrDefaultAsync(x => x.Id == meetingGroupProposalId);
    }
}
