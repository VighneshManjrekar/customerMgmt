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
    public class ProductServices:IProductServices
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductServices(IMapper _mapper, IProductRepository _productRepository)
        {
            mapper = _mapper;
            productRepository = _productRepository;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDTO)
        {
            try
            {
                var product = mapper.Map<Product>(productDTO);
                product.CreatedDate = DateTimeOffset.Now;
                product.UpdatedDate = DateTimeOffset.Now;
                var newProduct = await productRepository.CreateAsync(product);
                var mappedProduct = mapper.Map<ProductDTO>(newProduct);
                return mappedProduct;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var oldProduct = await productRepository.FindByIdAsync(id);
                if (oldProduct != null)
                {
                    var isDeleted = await productRepository.DeleteAsync(oldProduct);
                    return isDeleted;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            try
            {
                var products = await productRepository.FindAllAsync();
                var mappedProduct = mapper.Map<IEnumerable<ProductDTO>>(products);
                return mappedProduct;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await productRepository.FindByIdAsync(id);
                var mappedProduct = mapper.Map<ProductDTO>(product);
                return mappedProduct;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByIdAsync(IEnumerable<int> id)
        {
            try
            {
                var products = await productRepository.FetchProductsByIdAsync(id);
                var mappedProducts = mapper.Map<IEnumerable<ProductDTO>>(products);
                return mappedProducts;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<ProductDTO> UpdateProductAsync(int id, UpdateProductDTO updateProductDTO)
        {
            try
            {
                var oldProduct = await productRepository.FindByIdAsync(id);
                var myRequest = mapper.Map<Product>(updateProductDTO);
                if (oldProduct != null)
                {
                    myRequest.UpdatedDate = DateTimeOffset.Now;

                    var oldProductDTO = mapper.Map<UpdateProductDTO>(oldProduct);
                    var myRequestDTO = mapper.Map<UpdateProductDTO>(myRequest);

                    var updateRequestDTO = mapper.Map(myRequestDTO, oldProductDTO);
                    var updateRequest = mapper.Map<Product>(updateRequestDTO);

                    updateRequest.CreatedDate = oldProduct.CreatedDate;
                    updateRequest.CreatedBy = oldProduct.CreatedBy;

                    var updatedProduct = await productRepository.UpdateAsync(updateRequest);
                    var mappedProduct = mapper.Map<ProductDTO>(updatedProduct);
                    return mappedProduct;
                }
                else
                {
                    throw new InvalidOperationException($"Product with ID {id} not found.");
                }
            }catch (Exception e)
            {
                throw;
            }
        }
    }
}
