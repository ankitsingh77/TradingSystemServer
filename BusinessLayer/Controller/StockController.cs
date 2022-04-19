using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Controller
{
    public class StockController
    {

        public Guid CreateStock(string name, string symbol, double price, int volume)
        {
            var stockId = Guid.NewGuid();
            var stock = new Stock()
            {
                StockId = stockId,
                StockName = name,
                StockSymbol = symbol,
                Price = price,
                Volume = volume,
                OpeningPrice = price,
                HighPrice = price,
                LowPrice = price,
                StockPortfolios = new List<StockPortfolio>()
            };

            try
            {
                using(var dbContext = new TradingSystemDbContext())
                {
                    dbContext.Stocks.Add(stock);
                    dbContext.SaveChanges();
                }
            }
            catch
            {
                return Guid.Empty;
            }

            return stockId;
        }

        public List<Stock> GetAllStocks()
        {
            using (var dbContext = new TradingSystemDbContext())
            {
                return dbContext.Stocks.ToList();
            }
        }

        public Stock GetStock(Guid stockId)
        {
            using (var dbContext = new TradingSystemDbContext())
            {
                return dbContext.Stocks.Where(o => o.StockId == stockId).FirstOrDefault();
            }
        }

        public bool PurchaseStock(Guid stockId, Guid userId, int quantity)
        {
            using(var dbContext = new TradingSystemDbContext())
            {
                var stock = dbContext.Stocks.Where(o => o.StockId == stockId).FirstOrDefault();
                var user = dbContext.Users.Where(o => o.UserId == userId).FirstOrDefault();
                var portfolio = dbContext.PortFolios.Where(o => o.UserId == userId).FirstOrDefault();
                if (stock == null || user == null || portfolio == null)
                {
                    return false;
                }

                var stockPortfolio = dbContext.StockPortfolios.Where(o => o.StockId == stockId && o.ProtfolioId == portfolio.PortfolioId).FirstOrDefault();
                if(portfolio.Balance < stock.Price * quantity ||
                    stock.Volume < quantity)
                {
                    return false;
                }


                stock.Volume -= quantity;
                portfolio.Balance -= stock.Price * quantity;
                if (stockPortfolio == null)
                {
                    stockPortfolio = new StockPortfolio()
                    {
                        StockId = stockId,
                        ProtfolioId = portfolio.PortfolioId,
                        Quantity = quantity,
                        Stock = stock,
                        Portfolio = portfolio
                    };

                    dbContext.StockPortfolios.Add(stockPortfolio);
                }
                else
                {
                    stockPortfolio.Quantity += quantity;
                }

                dbContext.SaveChanges();
            }

            return true;
        }

        public bool SellStock(Guid stockId, Guid userId, int quantity)
        {
            using (var dbContext = new TradingSystemDbContext())
            {
                var stock = dbContext.Stocks.Where(o => o.StockId == stockId).FirstOrDefault();
                var user = dbContext.Users.Where(o => o.UserId == userId).FirstOrDefault();
                var portfolio = dbContext.PortFolios.Where(o => o.UserId == userId).FirstOrDefault();
                if (stock == null || user == null || portfolio == null)
                {
                    return false;
                }

                var stockPortfolio = dbContext.StockPortfolios.Where(o => o.StockId == stockId && o.ProtfolioId == portfolio.PortfolioId).FirstOrDefault();
                if (stockPortfolio == null || stockPortfolio.Quantity < quantity)
                {
                    return false;
                }


                stock.Volume += quantity;
                portfolio.Balance += stock.Price * quantity;
                stockPortfolio.Quantity -= quantity;
                dbContext.SaveChanges();
            }

            return true;
        }
    } 
}
