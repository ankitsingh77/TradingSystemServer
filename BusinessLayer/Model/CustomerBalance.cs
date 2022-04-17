using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class CustomerBalance
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double CashBalance { get; set; }
    }
}
