using BuildingBlocks.Core.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Infrastructure.Domain.MeetingGroupProposals;

public class MeetingGroupProposalRepository : EfRepositoryBase<AdministrationContext, MeetingGroupProposal, MeetingGroupProposalId>,IMeetingGroupProposalRepository
{
    public MeetingGroupProposalRepository(AdministrationContext context)
        : base(context)
    {
    }
}
