using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace CustomerManagement.Model
{

    [Table("Users")]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        
        [MinLength(10,ErrorMessage="Invalid Phone")]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [MinLength(8, ErrorMessage = "Password must be 8 characters long")]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Address { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        [ForeignKey("Gender")]
        public int GenderId { get; set; } = 1;
        public virtual Gender UserGender {get; set;}

        [ForeignKey("Role")]
       public int RoleId { get; set; } = 2;
        public virtual Role UserRole {get; set;}

        [ForeignKey("Enquiry")]
        public int? EnquiryId { get; set; }
        public virtual Enquiry UserOfEnquiry {  get; set;}

        public virtual ICollection<Order> Orders {get;set;}


        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public int? CreatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }



    }
}
