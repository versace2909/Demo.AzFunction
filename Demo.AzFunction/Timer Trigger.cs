using System;
using Azure.Storage.Queues;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Demo.AzFunction;

public class Timer_Trigger
{
    private readonly ILogger<Timer_Trigger> _logger;

    public Timer_Trigger(ILogger<Timer_Trigger> logger)
    {
        _logger = logger;
    }

    // [Function("Timer_Trigger")]
    public async Task Run([TimerTrigger("*/30 * * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        QueueClient queueClient = new QueueClient("UseDevelopmentStorage=true", "myqueue");
        var messages = await queueClient.ReceiveMessagesAsync(20);
        
        _logger.LogInformation("Number of messages: " + messages.Value.Length);
        foreach (var message in messages.Value)
        {
            _logger.LogInformation($"Message: {message.MessageText}");
            await queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);
        }
        _logger.LogInformation($"wait 60sec");

        await Task.Delay(90 * 1000);
        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            
        }
    }
}