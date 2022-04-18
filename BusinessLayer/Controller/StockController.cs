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
    } 
}
