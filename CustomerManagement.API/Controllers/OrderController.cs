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
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices orderServices;

        public OrderController(IOrderServices _orderServices)
        {
            orderServices = _orderServices;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> Get()
        {
            try
            {
                var orders = await orderServices.GetAllOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            try
            {
                var order = await orderServices.GetOrderByIdAsync(id);
                return Ok(order);
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

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<CreatedOrderDTO>> Post([FromBody] CreateOrderDTO createOrderDto)
        {
            try
            {
                var order = await orderServices.PostOrderAsync(createOrderDto);
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> Put(int id, [FromBody] UpdateOrderDTO updateOrderDTO)
        {
            try
            {
                if (id != updateOrderDTO.OrderId) throw new InvalidOperationException("Invalid id provided in request body");

                var updatedOrder = await orderServices.UpdateOrderAsync(id, updateOrderDTO);
                return Ok(updatedOrder);
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

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await orderServices.DeleteOrderAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
