namespace Demo.AzFunction.Models;

public enum TtUpdateType
{
    Snapshot,
    Incremental,
}

public class ProductMarketDepthModel
{
    public int DepthLevel { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }
}