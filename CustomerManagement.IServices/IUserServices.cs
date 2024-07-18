using CustomerManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.IServices
{
    public interface IUserServices
    {
        
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();

        Task<UserDTO> GetUserByIdAsync(int id);

        Task<bool> DeleteUserAsync(int id);

        Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO);

        Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDTO);
    }
}
