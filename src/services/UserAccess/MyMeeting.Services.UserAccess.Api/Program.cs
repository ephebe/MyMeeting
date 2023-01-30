using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

await ConfigureApplication(app);

await app.RunAsync();

static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    //builder.Services.AddSqlServerDbContext<MeetingsContext>(builder.Configuration);
    //builder.Services.AddSqlServerRepository<MeetingGroupProposal, MeetingGroupProposalId, MeetingGroupProposalRepository>();
    //builder.Services.AddUnitOfWork<MeetingsContext>(ServiceLifetime.Scoped, true);

    Assembly?[] assemblies = new[] { Assembly.GetAssembly(typeof(MeetingGroupProposalAcceptedIntegrationEventConsumer)) };
    builder.Services.AddCore(builder.Configuration);
    builder.Services.AddCqrs(assemblies);
    builder.Services.AddSqlServerMessagePersistence(builder.Configuration);
    builder.Services.AddCustomMassTransit(
            builder.Configuration,
            builder.Environment,
            assemblies,
            (context, cfg) =>
            {
                cfg.AddMeetingGroupProposeIntegrationEventPublishers();
                cfg.AddMeetingGroupProposalAcceptedIntegrationEventEndpoints(context);
            });
    builder.Services.AddAutoMapper(typeof(ProposeMeetingGroupCommand));

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
