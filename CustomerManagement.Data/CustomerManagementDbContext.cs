using CustomerManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Data
{
    public class CustomerManagementDbContext: DbContext
    {
        public CustomerManagementDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
        public DbSet<Payment> Payments { get; set; }
         // public DbSet<PaymentRecord> PaymentRecords{ get; set; }

        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<EnquiryDetail> EnquiryDetails { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<EnquiryInterest> EnquiryInterests { get; set; }

    }
}
