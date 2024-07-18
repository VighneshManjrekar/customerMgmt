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
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices _userServices)
        {
            userServices = _userServices;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            try
            {
                var users = await userServices.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            try
            {
                var user = await userServices.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] CreateUserDTO createUserDto)
        {
            try
            {
                var user = await userServices.CreateUserAsync(createUserDto);
                return Ok(user);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            try
            {
                if (id != updateUserDTO.UserId) throw new InvalidOperationException("Invalid id provided in request body");

                var updatedUser = await userServices.UpdateUserAsync(id, updateUserDTO);
                return Ok(updatedUser);
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

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await userServices.DeleteUserAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
