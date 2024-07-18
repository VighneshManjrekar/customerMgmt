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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        
        public RoleRepository(CustomerManagementDbContext context) : base(context)
        {
        }
    }
}
