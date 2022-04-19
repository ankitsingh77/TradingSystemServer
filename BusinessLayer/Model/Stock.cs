using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Stock
    {
        public virtual Guid StockId { get; set; }
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public double Price { get; set; }
        public int Volume { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double OpeningPrice { get; set; }

        public virtual ICollection<StockPortfolio> StockPortfolios { get; set; }
    }
}
