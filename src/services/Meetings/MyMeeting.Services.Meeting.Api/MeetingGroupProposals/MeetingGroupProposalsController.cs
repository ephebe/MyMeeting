using BuildingBlocks.Abstractions.CQRS.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMeeting.Services.Meetings.Application.MeetingGroupProposals;

namespace MyMeeting.Services.Meeting.Api.MeetingGroupProposals;

[Route("api/meetings/[controller]")]
[ApiController]
public class MeetingGroupProposalsController : ControllerBase
{
    private ICommandProcessor _commandProcessor;
    public MeetingGroupProposalsController(ICommandProcessor commandProcessor) 
    {
        _commandProcessor = commandProcessor;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> ProposeMeetingGroup(ProposeMeetingGroupRequest request,CancellationToken cancellationToken)
    {
        var command = new ProposeMeetingGroupCommand(
           request.Name,
           request.Description,
           request.LocationCity,
           request.LocationCountryCode);

        var result = await _commandProcessor.SendAsync(command, cancellationToken);

        return Results.Created($"ProposeMeeting/{result}", result);
    }
}
