using Demo.AzFunction.DbContext;
using Demo.AzFunction.Entities;
using Demo.AzFunction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Demo.AzFunction.Services;

public class MarketDepthService
{
    private DemoDbContext _coreRepo;
    private readonly ILogger<DemoBusQueue> _logger;

    public MarketDepthService(DemoDbContext coreRepo, ILogger<DemoBusQueue> logger)
    {
        _coreRepo = coreRepo;
        _logger = logger;
    }

    public async Task HandleMarketDepthAsync(ProductHistoryQueueModel productPriceQueueModel, int periodId,
        DateTime timeStamp)
    {
        var activeMarketDepth = await _coreRepo.ProductMarketDepths
            .FirstOrDefaultAsync(n => n.IsActive && n.ProductPeriodId == periodId);

        if (productPriceQueueModel.UpdateType == TtUpdateType.Incremental && productPriceQueueModel.IsBuy.HasValue)
        {
            if (activeMarketDepth == null)
            {
                activeMarketDepth = new ProductMarketDepth
                {
                    IsActive = true,
                    CreatedTimeStampUtc = timeStamp,
                    ProductPeriodId = periodId,
                    AsAtDateTimeUtc = timeStamp
                };

                _coreRepo.ProductMarketDepths.Add(activeMarketDepth);
            }

            UpdateActiveMarketDepth(activeMarketDepth, productPriceQueueModel, timeStamp);
            
            var currentMarketDepth = await _coreRepo.ProductMarketDepthOpenTrades
                .Where(x => x.ProductMarketDeptPriceHistoryId == activeMarketDepth.ProductMarketDeptPriceHistoryId &&
                            x.IsActive)
                .ToListAsync();
            currentMarketDepth.ForEach(x => x.IsActive = false);

            AddMarketDepthTrades(productPriceQueueModel.BidMarketDepth, activeMarketDepth, true);
            AddMarketDepthTrades(productPriceQueueModel.AskMarketDepth, activeMarketDepth, false);
        }

        // mark the active market depth as inactive
        if (productPriceQueueModel.IsEndMarketDepth && activeMarketDepth != null)
        {
            activeMarketDepth.IsActive = false;
        }
    }

    private static void UpdateActiveMarketDepth(ProductMarketDepth activeMarketDepth,
        ProductHistoryQueueModel productPriceQueueModel, DateTime timeStamp)
    {
        activeMarketDepth.OpenPrice = productPriceQueueModel.OpenPrice;
        activeMarketDepth.ClosePrice = productPriceQueueModel.ClosePrice;
        activeMarketDepth.HighPrice = productPriceQueueModel.HighPrice;
        activeMarketDepth.LowPrice = productPriceQueueModel.LowPrice;
        activeMarketDepth.CurrentPrice = productPriceQueueModel.CurrentPrice;
        activeMarketDepth.Volumne = productPriceQueueModel.Volume;
        activeMarketDepth.AsAtDateTimeUtc = timeStamp;
    }

    private void AddMarketDepthTrades(List<ProductMarketDepthModel> marketDepthModels,
        ProductMarketDepth activeMarketDepth, bool isBuy)
    {
        if (marketDepthModels.Any())
        {
            _coreRepo.ProductMarketDepthOpenTrades.AddRange(marketDepthModels.Select(x => new ProductMarketDepthOpenTrade
            {
                ProductMarketDeptPriceHistory = activeMarketDepth,
                Volume = x.Quantity,
                Price = x.Price,
                Buy = isBuy,
                Level = x.DepthLevel,
                IsActive = true,
            }).ToArray());
        }
    }
}