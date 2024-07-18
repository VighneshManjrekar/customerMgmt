using CustomerManagement.Data;
using CustomerManagement.IRepositories;
using CustomerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Repository
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        
        public GenderRepository(CustomerManagementDbContext context) : base(context)
        {
        }
    }
}
