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
                    Category = "Phone",
                    Description = "Phone",
                    Image = "image1",
                    Name = "IPhone",
                    Price = 1200M,
                    Summary = "iphone"
                },
                new Entities.Product
                {
                    Category = "Phone",
                    Description = "Phone",
                    Image = "image1",
                    Name = "Xiaomi",
                    Price = 1200M,
                    Summary = "iphone"
                },
                new Entities.Product
                {
                    Category = "Phone",
                    Description = "Phone",
                    Image = "image1",
                    Name = "Samsung",
                    Price = 1200M,
                    Summary = "iphone"
                },
                new Entities.Product
                {
                    Category = "Phone",
                    Description = "Phone",
                    Image = "image1",
                    Name = "Huawei",
                    Price = 1200M,
                    Summary = "iphone"
                },
            };
        }
    }
}