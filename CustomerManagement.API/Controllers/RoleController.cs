using CustomerManagement.DTO;
using CustomerManagement.IServices;
using CustomerManagement.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices roleServices;
        public RoleController(IRoleServices _roleServices)
        {
            roleServices = _roleServices;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> Get()
        {
            try
            {
                var roles = await roleServices.GetAllRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> Get(int id)
        {
            try
            {
                var role = await roleServices.GetRoleByIdAsync(id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult<Role>> Post([FromBody] RoleDTO roleDTO)
        {

            try
            {
                var role = await roleServices.CreateRoleAsync(roleDTO);
                return Ok(role);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RoleDTO>> Put(int id, [FromBody] UpdateRoleDTO updateRoleDTO)
        {
            try
            {
                if (id != updateRoleDTO.RoleId) throw new InvalidOperationException("Invalid id provided in request body");

                var updatedRole = await roleServices.UpdateRoleAsync(id, updateRoleDTO);
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

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await roleServices.DeleteRoleAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
