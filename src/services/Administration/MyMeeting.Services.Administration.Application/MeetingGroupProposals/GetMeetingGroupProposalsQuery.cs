using BuildingBlocks.Abstractions.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public record GetMeetingGroupProposalsQuery : IQuery<List<MeetingGroupProposalDto>>;
