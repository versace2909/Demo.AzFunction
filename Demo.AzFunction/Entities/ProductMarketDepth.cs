using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.AzFunction.Entities;

[Table("ProductMarketDepth")]
public partial class ProductMarketDepth
{
    [Key] public int ProductMarketDeptPriceHistoryId { get; set; }

    public int ProductPeriodId { get; set; }

    public DateTime AsAtDateTimeUtc { get; set; }

    [Column(TypeName = "decimal(10, 4)")] public decimal CurrentPrice { get; set; }

    [Column(TypeName = "decimal(10, 4)")] public decimal OpenPrice { get; set; }

    [Column(TypeName = "decimal(10, 4)")] public decimal ClosePrice { get; set; }

    [Column(TypeName = "decimal(10, 4)")] public decimal HighPrice { get; set; }

    [Column(TypeName = "decimal(10, 4)")] public decimal LowPrice { get; set; }

    [Column(TypeName = "decimal(10, 4)")] public decimal Volumne { get; set; }

    public DateTime CreatedTimeStampUtc { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("ProductMarketDeptPriceHistory")]
    public virtual ICollection<ProductMarketDepthOpenTrade> ProductMarketDepthOpenTrades { get; set; } =
        new List<ProductMarketDepthOpenTrade>();
}