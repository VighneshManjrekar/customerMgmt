using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CustomerManagement.Model
{
    [Table("Leads")]
    public class Lead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadId { get; set; }
        public bool IsActive { get; set; } = false;
        [ForeignKey("Enquiry")]
        public int EnquiryId { get; set; }
        public virtual Enquiry LeadOfEnquiry { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        
    }
}
