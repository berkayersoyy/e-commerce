using System.Collections.Generic;
using MongoDB.Driver;

namespace ECommerce.Product.API.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Product> productCollection)
        {
            bool existProduct = productCollection.Find(x => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Entities.Product> GetConfigureProducts()
        {
            return new List<Entities.Product>
            {
                new Entities.Product
                {
                    Name = "Monster Abra A5",
                    Category = "Laptop",
                    Description = "PC",
                    Image = "Monster.png",
                    Price = 10600M,
                    Summary = "Laptop"
                },
                new Entities.Product
                {
                    Name = "Macbook Air",
                    Category = "Laptop",
                    Description = "PC",
                    Image = "Macbook.png",
                    Price = 13500M,
                    Summary = "Laptop"
                }
            };
        }
    }
}