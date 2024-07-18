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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices paymentServices;
        public PaymentController(IPaymentServices _paymentServices)
        {
            paymentServices = _paymentServices;
        }
        // GET: api/<PaymentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> Get()
        {
            try
            {
                var payments = await paymentServices.GetAllPaymentsAsync();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> Get(int id)
        {
            try
            {
                var payment = await paymentServices.GetPaymentByIdAsync(id);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<PaymentController>
        [HttpPost]
        public async Task<ActionResult<Payment>> Post([FromBody] PaymentDTO paymentDTO)
        {

            try
            {
                var payment = await paymentServices.CreatePaymentAsync(paymentDTO);
                return Ok(payment);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentDTO>> Put(int id, [FromBody] UpdatePaymentDTO updatePaymentDTO)
        {
            try
            {
                if (id != updatePaymentDTO.PaymentId) throw new InvalidOperationException("Invalid id provided in request body");

                var updatedPayment = await paymentServices.UpdatePaymentAsync(id, updatePaymentDTO);
                return Ok(updatedPayment);
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

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await paymentServices.DeletePaymentAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
