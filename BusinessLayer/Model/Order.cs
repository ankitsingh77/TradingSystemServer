using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid StockId { get; set; }
        public Guid UserId { get; set; }
        public double Amount { get; set; }
        public DateTime OrderCreatedTime { get; set; }
        public DateTime OrderExcutedTime { get; set; }
        public DateTime OrderCancelledTime { get; set; }
        public DateTime OrderExpiredTime { get; set; }
        public Status OrderStatus { get; set; }
    }
}
