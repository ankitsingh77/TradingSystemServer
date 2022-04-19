using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TradingSystemDbContext : DbContext
    {
        public TradingSystemDbContext() : base("name=TradingSystemConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TradingSystemDbContext, BusinessLayer.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StockPortfolio>().HasKey(sp => new { sp.StockId, sp.ProtfolioId });
            modelBuilder.Entity<Portfolio>().HasMany(s => s.StockPortfolios).WithRequired().HasForeignKey(sp => sp.ProtfolioId);
            modelBuilder.Entity<Stock>().HasMany(s => s.StockPortfolios).WithRequired().HasForeignKey(sp => sp.StockId);

        }


        public DbSet<Calendar> Calender { get; set; }
        public DbSet<CustomerBalance> CustomerBalances { get; set; }
        public DbSet<MarketHours> MarketHours { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Portfolio> PortFolios {get;set;}
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StockPortfolio> StockPortfolios { get; set; }

    }
}
