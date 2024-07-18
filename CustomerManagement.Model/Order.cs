using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Model
{     
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderId { get; set; }

        [Precision(18, 2)]
        public decimal OrderTotal { get; set; }

        [Precision(18, 2)]
        public decimal Discount { get; set; } = 0;

        [Precision(18, 2)]
        public decimal Balance { get; set; }

        public DateTimeOffset? BalanceReminder { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

/*
        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }
        public virtual Payment OrderOfPayment { get; set; }
*/
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User OrderOfUser { get; set; }

        public virtual IEnumerable<OrderDetail> CurrentOrderDetails {  get; set; }
        

        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

        public virtual IEnumerable<Payment> PaymentsOfOrder { get; set; }

    }
}
