using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Abstractions.Domain;
using BuildingBlocks.Abstractions.Persistence;
using BuildingBlocks.Abstractions.Persistence.EfCore;
using BuildingBlocks.Core.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildBlocks.Persistence.EfCore.SqlServer;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlServerDbContext<TDbContext>(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<SqlServerOptions>? configurator = null,
        Action<DbContextOptionsBuilder>? builder = null)
        where TDbContext : DbContext, IDbFacadeResolver, IDomainEventContext
    {
        var config = configuration.GetSection(nameof(SqlServerOptions)).Get<SqlServerOptions>();

        services.Configure<SqlServerOptions>(configuration.GetSection(nameof(SqlServerOptions)));
        if (configurator is { })
            services.Configure(nameof(SqlServerOptions), configurator);

        Guard.Against.NullOrEmpty(config.ConnectionString, nameof(config.ConnectionString));

        services.AddDbContext<TDbContext>(options =>
        {
            options.UseSqlServer(config.ConnectionString, sqlOptions =>
            {
            }).UseSnakeCaseNamingConvention();

            builder?.Invoke(options);
        });

        services.AddScoped<IConnectionFactory, SqlServerConnectionFactory>();

        services.AddScoped<IDbFacadeResolver>(provider => provider.GetService<TDbContext>()!);
        services.AddScoped<IDomainEventContext>(provider => provider.GetService<TDbContext>()!);
        services.AddScoped<IDomainEventsAccessor, EfDomainEventAccessor>();

        return services;
    }

    public static IServiceCollection AddSqlServerCustomRepository(
        this IServiceCollection services,
        Type customRepositoryType)
    {
        services.Scan(scan => scan
            .FromAssembliesOf(customRepositoryType)
            .AddClasses(classes =>
                classes.AssignableTo(customRepositoryType)).As(typeof(IRepository<,>)).WithScopedLifetime()
            .AddClasses(classes =>
                classes.AssignableTo(customRepositoryType)).As(typeof(IPageRepository<>)).WithScopedLifetime()
        );

        return services;
    }

    public static IServiceCollection AddUnitOfWork<TContext>(
        this IServiceCollection services,
        ServiceLifetime lifeTime = ServiceLifetime.Scoped,
        bool registerGeneric = false)
        where TContext : EfDbContextBase
    {
        if (registerGeneric)
        {
            services.RegisterService<IUnitOfWork, EfUnitOfWork<TContext>>(lifeTime);
        }

        return services.RegisterService<IEfUnitOfWork<TContext>, EfUnitOfWork<TContext>>(lifeTime);
    }

    public static IServiceCollection AddSqlServerRepository<TEntity, TKey, TRepository>(
        this IServiceCollection services,
        ServiceLifetime lifeTime = ServiceLifetime.Scoped)
        where TEntity : class, IAggregate<TKey>
        where TRepository : class, IRepository<TEntity, TKey>
    {
        return services.RegisterService<IRepository<TEntity, TKey>, TRepository>(lifeTime);
    }


    private static IServiceCollection RegisterService<TService, TImplementation>(
        this IServiceCollection services,
        ServiceLifetime lifeTime = ServiceLifetime.Scoped)
        where TService : class
        where TImplementation : class, TService
    {
        ServiceDescriptor serviceDescriptor = lifeTime switch
        {
            ServiceLifetime.Singleton => ServiceDescriptor.Singleton<TService, TImplementation>(),
            ServiceLifetime.Scoped => ServiceDescriptor.Scoped<TService, TImplementation>(),
            ServiceLifetime.Transient => ServiceDescriptor.Transient<TService, TImplementation>(),
            _ => throw new ArgumentOutOfRangeException(nameof(lifeTime), lifeTime, null)
        };
        services.Add(serviceDescriptor);
        return services;
    }
}