using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Demo.AzFunction.DbContext;
using Demo.AzFunction.Models;
using Demo.AzFunction.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Demo.AzFunction;

public class DemoBusQueue
{
    private readonly ILogger<DemoBusQueue> _logger;

    public DemoBusQueue(ILogger<DemoBusQueue> logger)
    {
        _logger = logger;
    }

    [Function(nameof(DemoBusQueue))]
    public async Task Run(
        [ServiceBusTrigger("queue.1", Connection = "ServiceBusConnection", IsSessionsEnabled = true)]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message {Id} {SessionId}", message.MessageId, message.SessionId);

        var demoDbContext = new DemoDbContext();
        var vvv = new MarketDepthService(demoDbContext, _logger);
        var productHistoryQueueModel = JsonSerializer.Deserialize<ProductHistoryQueueModel>(message.Body);
        await vvv.HandleMarketDepthAsync(productHistoryQueueModel, productHistoryQueueModel.ProductPeriodCode == "BQ Jul25" ? 2 : 1, DateTime.Now);
        await demoDbContext.SaveChangesAsync();
        // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }
}