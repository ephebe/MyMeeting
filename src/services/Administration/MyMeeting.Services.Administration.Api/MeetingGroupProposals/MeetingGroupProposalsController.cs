using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using MyMeeting.Services.Administration.Application.MeetingGroupProposals;

namespace MyMeeting.Services.Administration.Api.MeetingGroupProposals;

[Route("api/administration/[controller]")]
[ApiController]
public class MeetingGroupProposalsController : ControllerBase
{
    private ICommandProcessor _commandProcessor;
    private IQueryProcessor _queryProcessor;
    public MeetingGroupProposalsController(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor)
    {
        _commandProcessor = commandProcessor;
        _queryProcessor = queryProcessor; ;
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(List<MeetingGroupProposalDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMeetingGroupProposals(CancellationToken cancellationToken)
    {
        var command = new GetMeetingGroupProposalsQuery();
        var meetingGroupProposals = await _queryProcessor.SendAsync(command, cancellationToken);

        return Ok(meetingGroupProposals);

    }

    [HttpPatch("{meetingGroupProposalId}/accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AcceptMeetingGroupProposal(Guid meetingGroupProposalId, CancellationToken cancellationToken)
    {
        var command = new AcceptMeetingGroupProposalCommand(meetingGroupProposalId);
        await _commandProcessor.SendAsync(command, cancellationToken);

        return Ok();
    }
}
