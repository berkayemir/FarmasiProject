using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dal
{
    public interface IProductDal
    {
        Task<List<Product>> GetAsync();
        Task<Product?> GetAsync(string id);
        Task CreateAsync(Product newBook);
        Task UpdateAsync(string id, Product updatedBook);
        Task RemoveAsync(string id);
    }
}
