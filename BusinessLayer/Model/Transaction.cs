using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid StockId { get; set; }
        public Guid UserId { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}
