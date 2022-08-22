using BuildingBlocks.Core.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meeting.Infrastructure.Domain.MeetingGroupProposals;

public class MeetingGroupProposalRepository : EfRepositoryBase<MeetingsContext, MeetingGroupProposal, MeetingGroupProposalId>,IMeetingGroupProposalRepository
{
    private readonly MeetingsContext _context;

    internal MeetingGroupProposalRepository(MeetingsContext context) : base(context)
    {
    
    }
}
