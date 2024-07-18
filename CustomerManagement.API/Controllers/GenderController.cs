using CustomerManagement.DTO;
using CustomerManagement.IServices;
using CustomerManagement.Model;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderServices genderServices;

        public GenderController(IGenderServices _genderServices)
        {
            genderServices = _genderServices;
        }

        // GET: api/<GenderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenderDTO>>> Get()
        {
            try
            {
                var genders = await genderServices.GetAllGendersAsync();
                return Ok(genders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<GenderController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<GenderDTO>> Get(int id)
        {
            try
            {
                var gender = await genderServices.GetGenderByIdAsync(id);
                return Ok(gender);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<GenderController>
        [HttpPost]
        public async Task<ActionResult<Gender>> Post([FromBody] GenderDTO genderDTO)
        {

            try
            {
                var gender = await genderServices.CreateGenderAsync(genderDTO);
                return Ok(gender);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // PUT api/<GenderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GenderDTO>> Put(int id, [FromBody] UpdateGenderDTO updateGenderDTO)
        {
            try
            {
                if (id != updateGenderDTO.GenderId) throw new InvalidOperationException("Invalid id provided in request body");

                var updatedRole = await genderServices.UpdateGenderAsync(id, updateGenderDTO);
                return Ok(updatedRole);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // DELETE api/<GenderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await genderServices.DeleteGenderAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
