using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dal
{
    public class MongoProductDal : IProductDal
    {
        private readonly IMongoCollection<Product> _productsCollection;

        public MongoProductDal(IOptions<ProductDatabaseSettings> productDatabaseSettings)
        {
            var mongoClient = new MongoClient(productDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDatabaseSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Product>(productDatabaseSettings.Value.ProductsCollectionName);
        }

        public async Task CreateAsync(Product newBook)
        {
            await _productsCollection.InsertOneAsync(newBook);
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _productsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetAsync(string id)
        {
            return await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _productsCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(string id, Product updatedBook)
        {
            await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
        }
    }
}
