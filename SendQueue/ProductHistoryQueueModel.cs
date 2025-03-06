namespace SendQueue;

public enum TtUpdateType
{
    Snapshot,
    Incremental,
}

public class ProductMarketDepth
{
    public int DepthLevel { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}

public class ProductPeriodPriceHistory : InstrumentModel
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

    public TtUpdateType UpdateType { get; set; }

    public bool IsEndMarketDepth { get; set; }

    public bool? IsBuy { get; set; }

    public decimal PriceTransaction { get; set; }

    public decimal QuantityTransaction { get; set; }
    
    public List<ProductMarketDepth> BidMarketDepth { get; set; }
    public List<ProductMarketDepth> AskMarketDepth { get; set; }

    public override string ToString()
    {
        return $"MarketCode: {MarketCode}, ProductCode: {ProductCode}, ProductPeriodCode: {ProductPeriodCode}, OpenPrice: {OpenPrice}, ClosePrice: {ClosePrice}, HighPrice: {HighPrice}, " +
               $"LowPrice: {LowPrice}, CurrentPrice: {CurrentPrice}, Volume: {Volume}, BidPrice: {BidPrice}, AskPrice: {AskPrice}, SettlePrice: {SettlePrice}, PriceTransaction:{PriceTransaction}, " +
               $"QuantityTransaction: {QuantityTransaction}, IsEndMarketDepth:{IsEndMarketDepth}, IsBuy:{IsBuy}, UpdateType: {UpdateType}";
    }
}