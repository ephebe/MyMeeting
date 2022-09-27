using BuildBlocks.Persistence.EfCore.SqlServer;
using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.CQRS;
using BuildingBlocks.Core.Persistence;
using BuildingBlocks.Core.Registrations;
using BuildingBlocks.Integration.MassTransit;
using BuildingBlocks.Messaging.Persistence.SqlServer.Extensions;
using MyMeeting.Services.Meeting.Infrastructure;
using MyMeeting.Services.Meeting.Infrastructure.Domain.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

await ConfigureApplication(app);

await app.RunAsync();

static void RegisterServices(WebApplicationBuilder builder) 
{
    builder.Services.AddSqlServerDbContext<MeetingsContext>(builder.Configuration);
    builder.Services.AddSqlServerRepository<MeetingGroupProposal, MeetingGroupProposalId, MeetingGroupProposalRepository>();
    builder.Services.AddUnitOfWork<MeetingsContext>(ServiceLifetime.Scoped);

    builder.Services.AddCore(builder.Configuration);
    builder.Services.AddCqrs();
    builder.Services.AddSqlServerMessagePersistence(builder.Configuration);
    builder.Services.AddCustomMassTransit(
            builder.Configuration,
            builder.Environment);
    //builder.Services.Decorate(typeof(ICommandHandler<>), typeof(DomainEventCommanHandlerDecorator<>));
    //builder.Services.Decorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
}

static async Task ConfigureApplication(WebApplication app)
{
    var environment = app.Environment;

    if (environment.IsDevelopment() || environment.IsEnvironment("docker"))
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseRouting();

    app.MapControllers();

}