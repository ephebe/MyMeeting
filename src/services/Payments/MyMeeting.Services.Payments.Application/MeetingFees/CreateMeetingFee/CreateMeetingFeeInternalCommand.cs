using BuildingBlocks.Core.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Payments.Application.MeetingFees.CreateMeetingFee;

public record CreateMeetingFeeInternalCommand(Guid Id, Guid PayerId, Guid MeetingId, decimal Value, string Currency) 
    : InternalCommand;

