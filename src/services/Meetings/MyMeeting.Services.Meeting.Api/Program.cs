using BuildBlocks.Persistence.EfCore.SqlServer;
using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.CQRS;
using BuildingBlocks.Core.Persistence;
using BuildingBlocks.Core.Registrations;
using MyMeeting.Services.Meeting.Infrastructure;
using MyMeeting.Services.Meeting.Infrastructure.Domain.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.




await app.RunAsync();

static void RegisterServices(WebApplicationBuilder builder) 
{
    builder.Services.AddSqlServerDbContext<MeetingsContext>(builder.Configuration);
    builder.Services.AddSqlServerRepository<MeetingGroupProposal, MeetingGroupProposalId, MeetingGroupProposalRepository>();
    builder.Services.AddUnitOfWork<MeetingsContext>(ServiceLifetime.Scoped);

    builder.Services.AddCqrs();

    //builder.Services.Decorate(typeof(ICommandHandler<>), typeof(DomainEventCommanHandlerDecorator<>));
    //builder.Services.Decorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
}