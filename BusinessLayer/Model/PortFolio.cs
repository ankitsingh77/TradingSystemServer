using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class PortFolio
    {
        public Guid PortfolioId { get; set; }
        public Guid UserId { get; set; }
        public double Balance { get; set; }
        public IList<Stock> Stocks { get; set; }
    }
}
