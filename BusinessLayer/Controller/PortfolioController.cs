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
        public PortFolio GetPortfolio(Guid userId)
        {
            using(var dbContext = new TradingSystemDbContext())
            {
                return dbContext.PortFolios.Where(o => o.UserId == userId).FirstOrDefault();
            }
        }
    }
}
