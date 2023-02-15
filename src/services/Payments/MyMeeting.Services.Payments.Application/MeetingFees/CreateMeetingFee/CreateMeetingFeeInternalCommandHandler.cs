using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MediatR;
using MyMeeting.Services.Payments.Core.MeetingFees;
using MyMeeting.Services.Payments.Core.Payers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Payments.Application.MeetingFees.CreateMeetingFee;

public class CreateMeetingFeeInternalCommandHandler : ICommandHandler<CreateMeetingFeeInternalCommand>
{
    IRepository<MeetingFee, MeetingFeeId> _meetingFeeRepository;
    public CreateMeetingFeeInternalCommandHandler(IRepository<MeetingFee,MeetingFeeId> meetingFeeRepository) 
    {
        _meetingFeeRepository = meetingFeeRepository;
    }

    public async Task<Unit> Handle(CreateMeetingFeeInternalCommand command, CancellationToken cancellationToken)
    {
        var meetingFee = MeetingFee.Create(
               new PayerId(command.PayerId),
               new MeetingId(command.MeetingId),
               MoneyValue.Of(command.Value, command.Currency));

        await _meetingFeeRepository.AddAsync(meetingFee);

        return Unit.Value;
    }
}
