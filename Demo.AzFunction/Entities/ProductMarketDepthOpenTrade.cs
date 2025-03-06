using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.AzFunction.Entities;

[Table("ProductMarketDepthOpenTrades")]
public partial class ProductMarketDepthOpenTrade
{
    [Key] public int ProductMarketDepthOpenTradeId { get; set; }

    public int ProductMarketDeptPriceHistoryId { get; set; }

    public bool Buy { get; set; }

    public bool Sell { get; }

    public int Level { get; set; }
    public bool IsActive { get; set; }

    [Column(TypeName = "decimal(10, 4)")] public decimal Price { get; set; }

    [Column(TypeName = "decimal(10, 4)")] public decimal Volume { get; set; }

    [StringLength(250)] public string? RefDetails { get; set; }

    [ForeignKey("ProductMarketDeptPriceHistoryId")]
    [InverseProperty("ProductMarketDepthOpenTrades")]
    public virtual ProductMarketDepth ProductMarketDeptPriceHistory { get; set; } = null!;
}