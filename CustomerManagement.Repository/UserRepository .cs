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

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CustomerManagementDbContext _context;
        public UserRepository(CustomerManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<IEnumerable<User>> FindAllAsync()
        {
            try
            {
                var users = await _context.Users.Include(rol => rol.UserRole).Include(gen => gen.UserGender).ToListAsync();
                return users;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async override Task<User> FindByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users.Include(rol => rol.UserRole).Include(gen => gen.UserGender).FirstOrDefaultAsync(i => i.UserId == id);
                if (user != null) return user;
                throw new Exception($"No User with Id:{id}");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
