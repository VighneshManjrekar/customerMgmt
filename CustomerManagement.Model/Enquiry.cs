using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Model
{
    [Table("Enquiries")]
    public class Enquiry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryId { get; set; }

        [MaxLength(50)]
        public string EnquiryName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(200)]
        public string EnquiryEmail { get; set; } = string.Empty;

        [MinLength(10, ErrorMessage = "Invalid Phone")]
        [MaxLength(20)]
        public string EnquiryPhone { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Source { get; set; } = string.Empty;

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status EnquiryOfStatus { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }


    }
}
