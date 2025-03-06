// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Azure.Messaging.ServiceBus;
using SendQueue;

string _connectionString =
    "Endpoint=sb://127.0.0.1;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
const int numOfMessagesPerBatch = 5;
const int numOfBatches = 5;

string queueName = "queue.1";
var client = new ServiceBusClient(_connectionString);
var sender = client.CreateSender(queueName);

var marketData1 = new ProductPeriodPriceHistory
{
    OpenPrice = 91,
    ClosePrice = 0,
    HighPrice = 91.5m,
    LowPrice = 90.75m,
    CurrentPrice = 91,
    Volume = 11,
    BidPrice = 91,
    AskPrice = 92,
    BidVolume = 2,
    AskVolume = 1,
    SettlePrice = 91,
    IsEndMarketDepth = false,
    IsBuy = true,
    UpdateType = TtUpdateType.Incremental,
    PriceTransaction = 91,
    QuantityTransaction = 2,
    BidMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 0, Quantity = 2, Price = 91 },
        new ProductMarketDepth { DepthLevel = 1, Quantity = 4, Price = 90.75m },
        new ProductMarketDepth { DepthLevel = 2, Quantity = 1, Price = 89 },
        new ProductMarketDepth { DepthLevel = 3, Quantity = 2, Price = 88.54m }
    },
    AskMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 1, Quantity = 2, Price = 93 },
        new ProductMarketDepth { DepthLevel = 0, Quantity = 1, Price = 92 }
    },
    MarketCode = "ASX",
    ProductCode = "BQ",
    ProductPeriodCode = "BQ Mar25",
    DatePeriod = ""
};

var marketData2 = new ProductPeriodPriceHistory
{
    OpenPrice = 91,
    ClosePrice = 0,
    HighPrice = 91.5m,
    LowPrice = 90.75m,
    CurrentPrice = 91,
    Volume = 11,
    BidPrice = 91,
    AskPrice = 92,
    BidVolume = 2,
    AskVolume = 1,
    SettlePrice = 91,
    IsEndMarketDepth = false,
    IsBuy = true,
    UpdateType = TtUpdateType.Incremental,
    PriceTransaction = 91,
    QuantityTransaction = 2,
    BidMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 0, Quantity = 2, Price = 91 },
        new ProductMarketDepth { DepthLevel = 1, Quantity = 4, Price = 90.75m },
        new ProductMarketDepth { DepthLevel = 2, Quantity = 2, Price = 89 },
        new ProductMarketDepth { DepthLevel = 3, Quantity = 2, Price = 88.54m }
    },
    AskMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 1, Quantity = 2, Price = 93 },
        new ProductMarketDepth { DepthLevel = 0, Quantity = 1, Price = 92 }
    },
    MarketCode = "ASX",
    ProductCode = "BQ",
    ProductPeriodCode = "BQ Mar25",
    DatePeriod = ""
};

var marketData3 = new ProductPeriodPriceHistory
{
    OpenPrice = 91,
    ClosePrice = 0,
    HighPrice = 91.5m,
    LowPrice = 90.75m,
    CurrentPrice = 91,
    Volume = 11,
    BidPrice = 91,
    AskPrice = 92,
    BidVolume = 2,
    AskVolume = 1,
    SettlePrice = 91,
    IsEndMarketDepth = false,
    IsBuy = true,
    UpdateType = TtUpdateType.Incremental,
    PriceTransaction = 91,
    QuantityTransaction = 2,
    BidMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 0, Quantity = 2, Price = 91 },
        new ProductMarketDepth { DepthLevel = 1, Quantity = 4, Price = 90.75m },
        new ProductMarketDepth { DepthLevel = 2, Quantity = 3, Price = 89 },
        new ProductMarketDepth { DepthLevel = 3, Quantity = 2, Price = 88.54m }
    },
    AskMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 1, Quantity = 2, Price = 93 },
        new ProductMarketDepth { DepthLevel = 0, Quantity = 1, Price = 92 }
    },
    MarketCode = "ASX",
    ProductCode = "BQ",
    ProductPeriodCode = "BQ Mar25",
    DatePeriod = ""
};

var marketData4 = new ProductPeriodPriceHistory
{
    OpenPrice = 91,
    ClosePrice = 0,
    HighPrice = 91.5m,
    LowPrice = 90.75m,
    CurrentPrice = 91,
    Volume = 11,
    BidPrice = 91,
    AskPrice = 92,
    BidVolume = 2,
    AskVolume = 1,
    SettlePrice = 91,
    IsEndMarketDepth = false,
    IsBuy = true,
    UpdateType = TtUpdateType.Incremental,
    PriceTransaction = 91,
    QuantityTransaction = 2,
    BidMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 0, Quantity = 2, Price = 91 },
        new ProductMarketDepth { DepthLevel = 1, Quantity = 4, Price = 90.75m },
        new ProductMarketDepth { DepthLevel = 2, Quantity = 2, Price = 89 },
        new ProductMarketDepth { DepthLevel = 3, Quantity = 4, Price = 88.54m }
    },
    AskMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 1, Quantity = 2, Price = 93 },
        new ProductMarketDepth { DepthLevel = 0, Quantity = 1, Price = 92 }
    },
    MarketCode = "ASX",
    ProductCode = "BQ",
    ProductPeriodCode = "BQ Mar25",
    DatePeriod = ""
};


var marketData5 = new ProductPeriodPriceHistory
{
    OpenPrice = 91,
    ClosePrice = 0,
    HighPrice = 91.5m,
    LowPrice = 90.75m,
    CurrentPrice = 91,
    Volume = 11,
    BidPrice = 91,
    AskPrice = 92,
    BidVolume = 2,
    AskVolume = 1,
    SettlePrice = 91,
    IsEndMarketDepth = false,
    IsBuy = true,
    UpdateType = TtUpdateType.Incremental,
    PriceTransaction = 91,
    QuantityTransaction = 2,
    BidMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 0, Quantity = 2, Price = 91 },
        new ProductMarketDepth { DepthLevel = 1, Quantity = 4, Price = 90.75m },
        new ProductMarketDepth { DepthLevel = 2, Quantity = 2, Price = 89 },
        new ProductMarketDepth { DepthLevel = 3, Quantity = 4, Price = 88.54m }
    },
    AskMarketDepth = new List<ProductMarketDepth>
    {
        new ProductMarketDepth { DepthLevel = 1, Quantity = 2, Price = 93 },
        new ProductMarketDepth { DepthLevel = 0, Quantity = 1, Price = 92 }
    },
    MarketCode = "ASX",
    ProductCode = "BQ",
    ProductPeriodCode = "BQ Jul25",
    DatePeriod = ""
};

var lists = new List<ProductPeriodPriceHistory> { marketData1, marketData2, marketData3, marketData4, marketData5 };

foreach (var list in lists)
{
    using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

    messageBatch.TryAddMessage(new ServiceBusMessage(JsonSerializer.Serialize(list))
    {
        SessionId = list.ProductPeriodCode
    });
    await sender.SendMessagesAsync(messageBatch);
}


// using ServiceBusMessageBatch messageBatch2 = await sender.CreateMessageBatchAsync();
//
//
// messageBatch2.TryAddMessage(new ServiceBusMessage(JsonSerializer.Serialize(marketData2))
// {
//     SessionId = marketData2.ProductPeriodCode
// });
//
// await sender.SendMessagesAsync(messageBatch2);


// for (int i = 1; i <= numOfBatches; i++)
// {
//     var sessionId = "session" + i;
//
//     for (int j = 1; j <= numOfMessagesPerBatch; j++)
//     {
//         
//     }
//
// }

await sender.DisposeAsync();
await client.DisposeAsync();

Console.WriteLine(
    $"{numOfBatches} batches with {numOfMessagesPerBatch} messages per batch has been published to the queue.");