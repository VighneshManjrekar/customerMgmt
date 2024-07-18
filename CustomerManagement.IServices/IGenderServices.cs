using CustomerManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.IServices
{
    public interface IGenderServices
    {
        Task<IEnumerable<GenderDTO>> GetAllGendersAsync();

        Task<GenderDTO> GetGenderByIdAsync(int id);

        Task<bool> DeleteGenderAsync(int id);

        Task<GenderDTO> UpdateGenderAsync(int id, UpdateGenderDTO updateGenderDTO);

        Task<GenderDTO> CreateGenderAsync(GenderDTO genderDTO);
    }
}
