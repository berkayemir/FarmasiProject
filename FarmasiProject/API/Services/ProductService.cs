using API.Dal;
using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _productDal.GetAsync();
        }

        public async Task<Product?> GetAsync(string id)
        {
            return await _productDal.GetAsync(id);
        }

        public async Task CreateAsync(Product newBook)
        {
            await _productDal.CreateAsync(newBook);
        }

        public async Task UpdateAsync(string id, Product updatedBook)
        {
            await _productDal.UpdateAsync(id, updatedBook);
        }

        public async Task RemoveAsync(string id)
        {
            await _productDal.RemoveAsync(id);
        }
    }
}
