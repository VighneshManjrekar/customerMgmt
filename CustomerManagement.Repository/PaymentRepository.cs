using CustomerManagement.Data;
using CustomerManagement.IRepositories;
using CustomerManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly CustomerManagementDbContext _context;
        public PaymentRepository(CustomerManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Payment>> FindAllAsync()
        {
            try
            {
                var payments = await _context.Payments.Include(od => od.OrderOfPayment).ToListAsync();
                return payments;
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
