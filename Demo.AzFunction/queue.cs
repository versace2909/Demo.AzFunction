using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Demo.AzFunction;

public class queue
{
    private readonly ILogger<queue> _logger;

    public queue(ILogger<queue> logger)
    {
        _logger = logger;
    }

    [Function(nameof(queue))]
    public void Run([QueueTrigger("myqueue", Connection = "")] QueueItemModel[] message)
    {
        _logger.LogInformation($"C# Queue trigger function processed: {message.Length} messages");
        
    }
}