using CustomerManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.IServices
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task<bool> DeleteProductAsync(int id);

        Task<ProductDTO> UpdateProductAsync(int id, UpdateProductDTO updateProductDTO);

        Task<ProductDTO> CreateProductAsync(ProductDTO productDTO);

        Task<IEnumerable<ProductDTO>> GetProductsByIdAsync(IEnumerable<int> id);
    }
}
