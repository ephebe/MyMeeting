using BuildBlocks.Persistence.EfCore.SqlServer;
using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Web;
using BuildingBlocks.Core.CQRS;
using BuildingBlocks.Core.Persistence;
using BuildingBlocks.Core.Registrations;
using BuildingBlocks.Core.Web;
using BuildingBlocks.Integration.MassTransit;
using BuildingBlocks.Messaging.Persistence.SqlServer.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MyMeeting.Services.Meeting.Infrastructure;
using MyMeeting.Services.Meeting.Infrastructure.Domain.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Application.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Application.Members;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Core.Members;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

await ConfigureApplication(app);

await app.RunAsync();

static void RegisterServices(WebApplicationBuilder builder) 
{
    builder.Services.AddControllers();

    builder.Services.AddSqlServerDbContext<MeetingsContext>(builder.Configuration);
    builder.Services.AddSqlServerRepository<MeetingGroupProposal, MeetingGroupProposalId, MeetingGroupProposalRepository>();
    builder.Services.AddUnitOfWork<MeetingsContext>(ServiceLifetime.Scoped,true);

    Assembly?[] assemblies = new[] { Assembly.GetAssembly(typeof(ProposeMeetingGroupCommandHandler)) };
    builder.Services.AddCore(builder.Configuration);
    builder.Services.AddCqrs(assemblies);
    builder.Services.AddSqlServerMessagePersistence(builder.Configuration);
    builder.Services.AddCustomMassTransit(
            builder.Configuration,
            builder.Environment);

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();
    builder.Services.AddTransient<IMemberContext, MemberContext>();
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