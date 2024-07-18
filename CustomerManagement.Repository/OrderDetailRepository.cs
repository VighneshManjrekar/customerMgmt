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

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailsRepository
    {
    public OrderDetailRepository(CustomerManagementDbContext context) : base(context)
    {
    }

    }
}
