using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Product.API.Data.Abstractions;
using ECommerce.Product.API.Repositories.Abstraction;
using MongoDB.Driver;

namespace ECommerce.Product.API.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly IProductContext _context;

        public ProductRepository(IProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.Product>> GetProducts()
        {
            return await _context.Products.Find(x => true).ToListAsync();
        }

        public async Task<Entities.Product> GetProduct(string id)
        {
            return await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProductsByName(string name)
        {
            var filter = Builders<Entities.Product>.Filter.ElemMatch(x => x.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProductsByCategory(string categoryName)
        {
            var filter = Builders<Entities.Product>.Filter.Eq(x => x.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task Create(Entities.Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Update(Entities.Product product)
        {
            var updatedResult =
                await _context.Products.ReplaceOneAsync(filter: x => x.Id == product.Id, replacement: product);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Entities.Product>.Filter.Eq(x => x.Id,id);
            var deleteResult = await _context.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }
    }
}