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
  [Table("OrderDetails")]
  public class OrderDetail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderDetailsId { get; set; }

    public int Quantity { get; set; } = 1;

    [Precision(18, 2)]
    public decimal ProductPrice { get; set; }

    // productPrice * quantity
    [Precision(18, 2)]
    public decimal ProdcutSubtotal { get; set; }

    // ProductSubtotal + Gst
    [Precision(18, 2)]
    public decimal ProductTotal { get; set; }

    [Precision(18, 2)]
    public decimal Discount { get; set; } = 0;

    [Precision(18, 2)]
    public decimal IGst { get; set; }
    [Precision(18, 2)]
    public decimal CGst { get; set; }
    [Precision(18, 2)]
    public decimal SGst { get; set; }
    [Precision(18, 2)]
    public decimal UTGst { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public virtual Order OrderDetailOfOrder { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product OrderDetailOfProduct { get; set; }

    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }


    public DateTimeOffset CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    public int UpdatedBy { get; set; }



  }
}
