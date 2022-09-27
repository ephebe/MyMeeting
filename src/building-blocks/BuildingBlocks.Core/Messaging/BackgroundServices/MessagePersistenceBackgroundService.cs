using BuildingBlocks.Abstractions.Messaging.PersistMessage;
using BuildingBlocks.Abstractions.Types;
using BuildingBlocks.Core.Messaging.MessagePersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Messaging.BackgroundServices;

public class MessagePersistenceBackgroundService : BackgroundService
{
    private readonly ILogger<MessagePersistenceBackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly MessagePersistenceOptions _options;
    private readonly IMachineInstanceInfo _machineInstanceInfo;

    private Task? _executingTask;

    public MessagePersistenceBackgroundService(
        ILogger<MessagePersistenceBackgroundService> logger,
        IOptions<MessagePersistenceOptions> options,
        IServiceProvider serviceProvider,
        IMachineInstanceInfo machineInstanceInfo)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _options = options.Value;
        _machineInstanceInfo = machineInstanceInfo;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            $"MessagePersistence Background Service is starting on client '{_machineInstanceInfo.ClientId}' and group '{_machineInstanceInfo.ClientGroup}'.");

        _executingTask = ProcessAsync(stoppingToken);

        return _executingTask;
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            $"MessagePersistence Background Service is stopping on client '{_machineInstanceInfo.ClientId}' and group '{_machineInstanceInfo.ClientGroup}'.");

        return base.StopAsync(cancellationToken);
    }

    private async Task ProcessAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IMessagePersistenceService>();
                await service.ProcessAllAsync(stoppingToken);
            }

            var delay = _options.Interval is { }
                ? TimeSpan.FromSeconds((int)_options.Interval)
                : TimeSpan.FromSeconds(30);

            await Task.Delay(delay, stoppingToken);
        }
    }
}
