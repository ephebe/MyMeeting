using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Messaging.PersistMessage;
using BuildingBlocks.Core.Extensions;
using BuildingBlocks.Core.Extensions.ServiceCollection;
using BuildingBlocks.Core.Messaging.MessagePersistence;
using BuildingBlocks.Messaging.Persistence.SqlServer.MessagePersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Persistence.SqlServer.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSqlServerMessagePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("SqlServer.EnableLegacyTimestampBehavior", true);

        var option = configuration.GetOptions<MessagePersistenceOptions>(nameof(MessagePersistenceOptions));

        Guard.Against.Null(option, nameof(MessagePersistenceOptions));
        Guard.Against.NullOrEmpty(option.ConnectionString, nameof(option.ConnectionString));

        services.AddDbContext<MessagePersistenceDbContext>(options =>
        {
            options.UseSqlServer(option.ConnectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }).UseSnakeCaseNamingConvention();
        });

        services.ReplaceScoped<IMessagePersistenceRepository, SqlServerMessagePersistenceRepository>();
    }
}
