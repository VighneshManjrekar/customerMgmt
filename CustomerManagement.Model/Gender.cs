using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Model
{
    [Table("Genders")]
    [Index(nameof(GenderName),IsUnique =true)]
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenderId { get; set; }

        [Required]
        public string GenderName { get; set; } = string.Empty;

        public DateTimeOffset? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        
    }
}
