using System.Text.Json;

namespace Demo.AzFunction.Models;

public class ProductHistoryQueueModel
{
    public decimal OpenPrice { get; set; }

    public decimal ClosePrice { get; set; }

    public decimal HighPrice { get; set; }

    public decimal LowPrice { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal Volume { get; set; }

    public decimal BidPrice { get; set; }

    public decimal AskPrice { get; set; }

    public decimal? BidVolume { get; set; }

    public decimal? AskVolume { get; set; }

    public decimal? SettlePrice { get; set; }

    public bool IsEndMarketDepth { get; set; }

    public bool? IsBuy { get; set; }

    public decimal? PriceTransaction { get; set; }

    public decimal? QuantityTransaction { get; set; }

    public TtUpdateType UpdateType { get; set; }

    public string MarketCode { get; set; } = string.Empty;

    public string ProductCode { get; set; } = string.Empty;

    public string ProductPeriodCode { get; set; } = string.Empty;

    public List<ProductMarketDepthModel> BidMarketDepth { get; set; } = new List<ProductMarketDepthModel>();

    public List<ProductMarketDepthModel> AskMarketDepth { get; set; } = new List<ProductMarketDepthModel>();

    public override string ToString()
    {
        //return full properties string
        return $"OpenPrice: {OpenPrice}, ClosePrice: {ClosePrice}, HighPrice: {HighPrice}, LowPrice: {LowPrice}, " +
               $"CurrentPrice: {CurrentPrice}, Volume: {Volume}, BidPrice: {BidPrice}, AskPrice: {AskPrice}, " +
               $"BidVolume: {BidVolume}, AskVolume: {AskVolume}, SettlePrice: {SettlePrice}, IsEndMarketDepth: {IsEndMarketDepth}, " +
               $"IsBuy: {IsBuy}, PriceTransaction: {PriceTransaction}, QuantityTransaction: {QuantityTransaction}, UpdateType: {UpdateType}, " +
               $"MarketCode: {MarketCode}, ProductCode: {ProductCode}, ProductPeriodCode: {ProductPeriodCode}, " +
               $"BidMarketDepth: {JsonSerializer.Serialize(BidMarketDepth)}, AskMarketDepth: {JsonSerializer.Serialize(AskMarketDepth)}";
    }
}