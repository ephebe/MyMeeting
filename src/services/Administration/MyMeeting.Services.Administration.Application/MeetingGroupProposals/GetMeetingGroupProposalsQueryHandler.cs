using BuildingBlocks.Abstractions.CQRS.Queries;
using BuildingBlocks.Abstractions.Persistence.EfCore;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public class GetMeetingGroupProposalsQueryHandler : IQueryHandler<GetMeetingGroupProposalsQuery, List<MeetingGroupProposalDto>>
{
    private readonly IConnectionFactory _connectionFactory;

    public GetMeetingGroupProposalsQueryHandler(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<MeetingGroupProposalDto>> Handle(GetMeetingGroupProposalsQuery query, CancellationToken cancellationToken)
    {
        var connection = _connectionFactory.GetOrCreateConnection();

        string sql = "SELECT " +
                     $"[meeting_group_proposal].[id] AS [{nameof(MeetingGroupProposalDto.Id)}], " +
                     $"[meeting_group_proposal].[name] AS [{nameof(MeetingGroupProposalDto.Name)}], " +
                     $"[meeting_group_proposal].[proposal_user_id] AS [{nameof(MeetingGroupProposalDto.ProposalUserId)}], " +
                     $"[meeting_group_proposal].[location_city] AS [{nameof(MeetingGroupProposalDto.LocationCity)}], " +
                     $"[meeting_group_proposal].[location_country_code] AS [{nameof(MeetingGroupProposalDto.LocationCountryCode)}], " +
                     $"[meeting_group_proposal].[description] AS [{nameof(MeetingGroupProposalDto.Description)}], " +
                     $"[meeting_group_proposal].[proposal_date] AS [{nameof(MeetingGroupProposalDto.ProposalDate)}], " +
                     $"[meeting_group_proposal].[status_code] AS [{nameof(MeetingGroupProposalDto.StatusCode)}], " +
                     $"[meeting_group_proposal].[decision_date] AS [{nameof(MeetingGroupProposalDto.DecisionDate)}], " +
                     $"[meeting_group_proposal].[decision_user_id] AS [{nameof(MeetingGroupProposalDto.DecisionUserId)}], " +
                     $"[meeting_group_proposal].[decision_code] AS [{nameof(MeetingGroupProposalDto.DecisionCode)}], " +
                     $"[meeting_group_proposal].[decision_reject_reason] AS [{nameof(MeetingGroupProposalDto.DecisionRejectReason)}] " +
                     "FROM [v_meeting_group_proposals] AS [meeting_group_proposal] ";

        return (await connection.QueryAsync<MeetingGroupProposalDto>(sql)).AsList();
    }
}
