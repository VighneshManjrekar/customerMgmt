using CustomerManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.IServices
{
    public interface IRoleServices
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();

        Task<RoleDTO> GetRoleByIdAsync(int id);

        Task<bool> DeleteRoleAsync(int id);

        Task<RoleDTO> UpdateRoleAsync(int id, UpdateRoleDTO updateRoleDTO);

        Task<RoleDTO> CreateRoleAsync(RoleDTO roleDTO);
    }
}
