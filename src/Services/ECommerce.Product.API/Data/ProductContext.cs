using ECommerce.Product.API.Data.Abstractions;
using ECommerce.Product.API.Settings;
using MongoDB.Driver;

namespace ECommerce.Product.API.Data
{
    public class ProductContext:IProductContext
    {
        public IMongoCollection<Entities.Product> Products { get; set; }

        public ProductContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Entities.Product>(settings.CollectionName);

            ProductContextSeed.SeedData(Products);
        }
    }
}