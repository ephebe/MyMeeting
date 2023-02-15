using BuildingBlocks.Abstractions.CQRS.Commands;
using MediatR;
using MyMeeting.Services.Meetings.Application.MeetingGroups.CreateNewMeetingGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings.SendMeetingAttendeeAddedEmail;

//public class SendMeetingAttendeeAddedEmailInternalCommandHandler : ICommandHandler<SendMeetingAttendeeAddedEmailInternalCommand>
//{
//    private readonly ISqlConnectionFactory _sqlConnectionFactory;
//    private readonly IEmailSender _emailSender;

//    internal SendMeetingAttendeeAddedEmailCommandHandler(
//        ISqlConnectionFactory sqlConnectionFactory,
//        IEmailSender emailSender)
//    {
//        _sqlConnectionFactory = sqlConnectionFactory;
//        _emailSender = emailSender;
//    }

//    public async Task<Unit> Handle(SendMeetingAttendeeAddedEmailCommand request, CancellationToken cancellationToken)
//    {
//        var connection = _sqlConnectionFactory.GetOpenConnection();

//        var member = await MembersQueryHelper.GetMember(request.AttendeeId, connection);

//        var meeting = await MeetingsQueryHelper.GetMeeting(request.MeetingId, connection);

//        var email = new EmailMessage(
//            member.Email,
//            $"You joined to {meeting.Title} meeting.",
//            $"You joined to {meeting.Title} title at {meeting.TermStartDate.ToShortDateString()} - {meeting.TermEndDate.ToShortDateString()}, location {meeting.LocationAddress}, {meeting.LocationPostalCode}, {meeting.LocationCity}");

//        _emailSender.SendEmail(email);

//        return Unit.Value;
//    }
//}
