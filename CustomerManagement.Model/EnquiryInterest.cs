using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Model
{
    [Table("EnquiryInterests")]
    public class EnquiryInterest
    {
        public int EnquiryInterestId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product EnquiryInterestOfProduct { get; set; }

        [ForeignKey("Enquiry")]
        public int EnquiryId {  get; set; }
        public virtual Enquiry EnquiryInterestOfEnquiry { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }




    }
}
