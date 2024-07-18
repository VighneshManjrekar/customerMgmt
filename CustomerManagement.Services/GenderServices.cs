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
    public class GenderServices : IGenderServices
    {
        private readonly IMapper mapper;
        private readonly IGenderRepository genderRepository;

        public GenderServices(IMapper _mapper, IGenderRepository _genderRepository)
        {
            mapper = _mapper;
            genderRepository = _genderRepository;
        }

        public async Task<GenderDTO> CreateGenderAsync(GenderDTO genderDTO)
        {
            try
            {
                var gender = mapper.Map<Gender>(genderDTO);
                gender.CreatedDate = DateTimeOffset.Now;
                gender.UpdatedDate = DateTimeOffset.Now;
                var newGender = await genderRepository.CreateAsync(gender);
                var mappedGender = mapper.Map<GenderDTO>(newGender);
                return mappedGender;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> DeleteGenderAsync(int id)
        {
            try
            {
                var oldGender = await genderRepository.FindByIdAsync(id);
                if (oldGender != null)
                {
                    var isDeleted = await genderRepository.DeleteAsync(oldGender);
                    return isDeleted;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GenderDTO>> GetAllGendersAsync()
        {
            try
            {
                var genders = await genderRepository.FindAllAsync();
                var mappedGender = mapper.Map<IEnumerable<GenderDTO>>(genders);
                return mappedGender;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<GenderDTO> GetGenderByIdAsync(int id)
        {
            try
            {
                var gender = await genderRepository.FindByIdAsync(id);
                var mappedGender = mapper.Map<GenderDTO>(gender);
                return mappedGender;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<GenderDTO> UpdateGenderAsync(int id, UpdateGenderDTO updateGenderDTO)
        {
            try
            {
                var oldGender = await genderRepository.FindByIdAsync(id);
                var myRequest = mapper.Map<Gender>(updateGenderDTO);
                if (oldGender != null)
                {
                    myRequest.UpdatedDate = DateTimeOffset.Now;
                    var oldGenderDTO = mapper.Map<UpdateGenderDTO>(oldGender);
                    var myRequestDTO = mapper.Map<UpdateGenderDTO>(myRequest);

                    var updateRequestDTO = mapper.Map(myRequestDTO, oldGenderDTO);
                    var updateRequest = mapper.Map<Gender>(updateRequestDTO);
                    
                    updateRequest.CreatedDate = oldGender.CreatedDate;
                    updateRequest.CreatedBy = oldGender.CreatedBy;

                    var updatedGender = await genderRepository.UpdateAsync(updateRequest);
                    var mappedGender = mapper.Map<GenderDTO>(updatedGender);
                    return mappedGender;
                }
                else
                {
                    throw new InvalidOperationException($"Gender with ID {id} not found.");
                }
            }catch (Exception e)
            {
                throw;
            }
        }
    }
}
