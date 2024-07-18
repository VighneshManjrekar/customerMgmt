using CustomerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.IRepositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Task <Dictionary<int,Product>> FetchProductsByIdAsync (IEnumerable<int> id);
    }
}
