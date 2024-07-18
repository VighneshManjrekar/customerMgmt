using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Model
{   
    [Table("EqnuiryDetails")]
    public class EnquiryDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryDetailsId { get; set; }

        [MaxLength(1000)]
        public string Note { get; set; } = string.Empty;
        
        [ForeignKey("Enquiry")]
        public int EnquiryId { get; set; }
        public virtual Enquiry EnquiryDetailsOfEnquiry { get; set; }

        public DateTimeOffset? FollowUpDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }


    }
}
