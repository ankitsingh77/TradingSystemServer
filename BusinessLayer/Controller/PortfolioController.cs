using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Controller
{
    public class PortfolioController
    {
        public Portfolio GetPortfolio(Guid userId, out List<StockPortfolio> stockPortfolios)
        {
            using(var dbContext = new TradingSystemDbContext())
            {
                var portfolio = dbContext.PortFolios.Where(o => o.UserId == userId).FirstOrDefault(); ;
                stockPortfolios = portfolio.StockPortfolios.ToList();
                return portfolio;
            }
        }

        public double AddBalance(Guid userId, double amountToAdd)
        {
            double balance = 0;
            using(var dbContext = new TradingSystemDbContext())
            {
                var portfolio = dbContext.PortFolios.Where(o => o.UserId == userId).FirstOrDefault();
                portfolio.Balance += amountToAdd;
                balance = portfolio.Balance;
                dbContext.SaveChanges();
            }

            return balance;            
        }
    }
}
