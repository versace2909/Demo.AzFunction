using Demo.AzFunction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.AzFunction.DbContext;

public class DemoDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<ProductMarketDepth> ProductMarketDepths { get; set; }
    public DbSet<ProductMarketDepthOpenTrade> ProductMarketDepthOpenTrades { get; set; }
    
    public DemoDbContext()
    {
    }

    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine)
            .UseSqlServer("Server=.;Database=DemoDb;User Id=sa;Password=Zaq1Zxcv@@11;Persist Security Info=False;Encrypt=False");
        base.OnConfiguring(optionsBuilder);
    }
}