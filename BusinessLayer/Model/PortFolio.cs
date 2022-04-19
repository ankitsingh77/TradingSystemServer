using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Portfolio
    {
        public virtual Guid PortfolioId { get; set; }
        public Guid UserId { get; set; }
        public double Balance { get; set; }
        public virtual ICollection<StockPortfolio> StockPortfolios { get; set; }
    }
}
