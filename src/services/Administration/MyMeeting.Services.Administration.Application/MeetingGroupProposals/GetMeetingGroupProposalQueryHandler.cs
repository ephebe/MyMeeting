using BuildingBlocks.Abstractions.CQRS.Queries;
using BuildingBlocks.Abstractions.Persistence.EfCore;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

internal class GetMeetingGroupProposalQueryHandler : IQueryHandler<GetMeetingGroupProposalQuery, MeetingGroupProposalDto>
{
    private readonly IConnectionFactory _connectionFactory;

    public async Task<MeetingGroupProposalDto> Handle(GetMeetingGroupProposalQuery request, CancellationToken cancellationToken)
    {
        var connection = _connectionFactory.GetOrCreateConnection();

        string sql = "SELECT " +
                     $"[MeetingGroupProposal].[Id] AS [{nameof(MeetingGroupProposalDto.Id)}], " +
                     $"[MeetingGroupProposal].[Name] AS [{nameof(MeetingGroupProposalDto.Name)}], " +
                     $"[MeetingGroupProposal].[ProposalUserId] AS [{nameof(MeetingGroupProposalDto.ProposalUserId)}], " +
                     $"[MeetingGroupProposal].[LocationCity] AS [{nameof(MeetingGroupProposalDto.LocationCity)}], " +
                     $"[MeetingGroupProposal].[LocationCountryCode] AS [{nameof(MeetingGroupProposalDto.LocationCountryCode)}], " +
                     $"[MeetingGroupProposal].[Description] AS [{nameof(MeetingGroupProposalDto.Description)}], " +
                     $"[MeetingGroupProposal].[ProposalDate] AS [{nameof(MeetingGroupProposalDto.ProposalDate)}], " +
                     $"[MeetingGroupProposal].[StatusCode] AS [{nameof(MeetingGroupProposalDto.StatusCode)}], " +
                     $"[MeetingGroupProposal].[DecisionDate] AS [{nameof(MeetingGroupProposalDto.DecisionDate)}], " +
                     $"[MeetingGroupProposal].[DecisionUserId] AS [{nameof(MeetingGroupProposalDto.DecisionUserId)}], " +
                     $"[MeetingGroupProposal].[DecisionCode] AS [{nameof(MeetingGroupProposalDto.DecisionCode)}], " +
                     $"[MeetingGroupProposal].[DecisionRejectReason] AS [{nameof(MeetingGroupProposalDto.DecisionRejectReason)}] " +
                     "FROM [administration].[v_MeetingGroupProposals] AS [MeetingGroupProposal] " +
                     "WHERE [MeetingGroupProposal].[Id] = @MeetingGroupProposalId";

        return await connection.QuerySingleAsync<MeetingGroupProposalDto>(sql, new { request.meetingGroupProposalId });
    }
}
