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
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            try
            {
                var products = await productServices.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            try
            {
                var product = await productServices.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] ProductDTO prodcutDTO)
        {

            try
            {
                var product = await productServices.CreateProductAsync(prodcutDTO);
                return Ok(product);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> Put(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            try
            {
                if (id != updateProductDTO.ProductId) throw new InvalidOperationException("Invalid id provided in request body");

                var updatedProduct = await productServices.UpdateProductAsync(id, updateProductDTO);
                return Ok(updatedProduct);
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


        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await productServices.DeleteProductAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
