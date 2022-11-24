using BuildBlocks.Persistence.EfCore.SqlServer;
using BuildingBlocks.Abstractions.Web;
using BuildingBlocks.Core.Registrations;
using BuildingBlocks.Core.Web;
using BuildingBlocks.Integration.MassTransit;
using BuildingBlocks.Messaging.Persistence.SqlServer.Extensions;
using MyMeeting.Services.Administration.Api.Extensions;
using MyMeeting.Services.Administration.Api.MeetingGroupProposals;
using MyMeeting.Services.Administration.Application.MeetingGroupProposals;
using MyMeeting.Services.Administration.Application.Users;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals;
using MyMeeting.Services.Administration.Core.Users;
using MyMeeting.Services.Administration.Infrastructure;
using MyMeeting.Services.Administration.Infrastructure.Domain.MeetingGroupProposals;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

await ConfigureApplication(app);

await app.RunAsync();

static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    builder.Services.AddSqlServerDbContext<AdministrationContext>(builder.Configuration);
    builder.Services.AddSqlServerRepository<MeetingGroupProposal, MeetingGroupProposalId, MeetingGroupProposalRepository>();
    builder.Services.AddUnitOfWork<AdministrationContext>(ServiceLifetime.Scoped, true);

    Assembly?[] assemblies = new[] { Assembly.GetAssembly(typeof(MeetingGroupProposedIntegrationEventConsumer)) };
    builder.Services.AddCore(builder.Configuration);
    builder.Services.AddCqrs(assemblies);
    builder.Services.AddSqlServerMessagePersistence(builder.Configuration);
    builder.Services.AddCustomMassTransit(
            builder.Configuration,
            builder.Environment,
            assemblies,
            (context, cfg) =>
            {
                cfg.AddMeetingGroupProposedIntegrationEventEndpoints(context);
                cfg.AddMeetingGroupProposeAcceptedIntegrationEventPublishers();
            });
    builder.Services.AddAutoMapper(typeof(RequestMeetingGroupProposalVerificationCommand));

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();
    builder.Services.AddTransient<IUserContext, UserContext>();
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

