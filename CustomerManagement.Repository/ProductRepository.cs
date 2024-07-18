using CustomerManagement.Data;
using CustomerManagement.IRepositories;
using CustomerManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        
        private readonly CustomerManagementDbContext context;
        public ProductRepository(CustomerManagementDbContext _context) : base(_context)
        {
            context  = _context;
        }

        public async Task<Dictionary<int,Product>> FetchProductsByIdAsync(IEnumerable<int> id)
        {
            try
            {
                var products = await context.Products.Where(product => id.Contains(product.ProductId)).ToListAsync();
                var productDictionary = products.ToDictionary(p => p.ProductId, p => p);
                return productDictionary;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
