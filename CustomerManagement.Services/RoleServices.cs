using AutoMapper;
using CustomerManagement.DTO;
using CustomerManagement.IRepositories;
using CustomerManagement.IServices;
using CustomerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Services
{
    public class RoleServices:IRoleServices
    {
        private readonly IMapper mapper;
        private readonly IRoleRepository roleRepository;

        public RoleServices(IMapper _mapper, IRoleRepository _roleRepository)
        {
            mapper = _mapper;
            roleRepository = _roleRepository;
        }

        public async Task<RoleDTO> CreateRoleAsync(RoleDTO roleDTO)
        {
            try
            {
                var role = mapper.Map<Role>(roleDTO);
                role.CreatedDate = DateTimeOffset.Now;
                role.UpdatedDate = DateTimeOffset.Now;
                var newRole = await roleRepository.CreateAsync(role);
                var mappedRole = mapper.Map<RoleDTO>(newRole);
                return mappedRole;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            try
            {
                var oldRole = await roleRepository.FindByIdAsync(id);
                if (oldRole != null)
                {
                    var isDeleted = await roleRepository.DeleteAsync(oldRole);
                    return isDeleted;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            try
            {
                var roles = await roleRepository.FindAllAsync();
                var mappedRole = mapper.Map<IEnumerable<RoleDTO>>(roles);
                return mappedRole;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<RoleDTO> GetRoleByIdAsync(int id)
        {
            try
            {
                var role = await roleRepository.FindByIdAsync(id);
                var mappedRole = mapper.Map<RoleDTO>(role);
                return mappedRole;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<RoleDTO> UpdateRoleAsync(int id, UpdateRoleDTO updateRoleDTO)
        {
            try
            {
                var oldRole = await roleRepository.FindByIdAsync(id);
                var myRequest = mapper.Map<Role>(updateRoleDTO);
                if (oldRole != null)
                {
                    myRequest.UpdatedDate = DateTimeOffset.Now;

                    var oldRoleDTO = mapper.Map<UpdateRoleDTO>(oldRole);
                    var myRequestDTO = mapper.Map<UpdateRoleDTO>(myRequest);

                    var updateRequestDTO = mapper.Map(myRequestDTO, oldRoleDTO);
                    var updateRequest = mapper.Map<Role>(updateRequestDTO);

                    updateRequest.CreatedDate = oldRole.CreatedDate;
                    updateRequest.CreatedBy = oldRole.CreatedBy;

                    var updatedRole = await roleRepository.UpdateAsync(updateRequest);
                    var mappedRole = mapper.Map<RoleDTO>(updatedRole);
                    return mappedRole;
                }
                else
                {
                    throw new InvalidOperationException($"Role with ID {id} not found.");
                }
            }catch (Exception e)
            {
                throw;
            }
        }
    }
}
