using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Model
{
    [Table("Payments")]
    public class Payment
    {
        public int PaymentId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order OrderOfPayment { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

    }
}
