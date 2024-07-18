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
    [Table("Roles")]
    [Index(nameof(RoleName), IsUnique = true)]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTimeOffset? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        
        // public virtual ICollection<User> Users { get;set; }
    }
}
