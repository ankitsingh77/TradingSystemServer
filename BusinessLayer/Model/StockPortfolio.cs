using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class StockPortfolio
    {
        public virtual Guid StockId {get;set;}
        public virtual Guid ProtfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual Stock Stock { get; set; }

        public virtual int Quantity { get;set; }
    }
}
