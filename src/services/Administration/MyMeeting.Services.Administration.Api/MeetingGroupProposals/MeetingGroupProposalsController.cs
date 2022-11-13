using BuildingBlocks.Abstractions.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using MyMeeting.Services.Administration.Application.MeetingGroupProposals;

namespace MyMeeting.Services.Administration.Api.MeetingGroupProposals;

[Route("api/administration/[controller]")]
[ApiController]
public class MeetingGroupProposalsController : ControllerBase
{
    private ICommandProcessor _commandProcessor;
    public MeetingGroupProposalsController(ICommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    //[HttpGet("")]
    //[ProducesResponseType(typeof(List<MeetingGroupProposalDto>), StatusCodes.Status200OK)]
    //public async Task<IActionResult> GetMeetingGroupProposals()
    //{
    //    var meetingGroupProposals =
    //        await _administrationModule.ExecuteQueryAsync(new GetMeetingGroupProposalsQuery());

    //    return Ok(meetingGroupProposals);
    //}

    [HttpPatch("{meetingGroupProposalId}/accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AcceptMeetingGroupProposal(Guid meetingGroupProposalId, CancellationToken cancellationToken)
    {
        var command = new AcceptMeetingGroupProposalCommand(meetingGroupProposalId);
        await _commandProcessor.SendAsync(command, cancellationToken);

        return Ok();
    }
}
