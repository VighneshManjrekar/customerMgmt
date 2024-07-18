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

    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public bool IsSubscribable { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [MaxLength(700)]
        public string ProductDescription { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal ProductPrice { get; set; }
        public int DurationInDays { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        [Precision(18, 2)]
        public decimal IGstRate { get; set; }
        [Precision(18, 2)]
        public decimal CGstRate { get; set; }
        [Precision(18, 2)]
        public decimal UTGstRate { get; set; }
        [Precision(18, 2)]
        public decimal SGstRate { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

    }
}
