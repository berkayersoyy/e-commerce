using MongoDB.Driver;



namespace ECommerce.Product.API.Data.Abstractions
{
    public interface IProductContext
    {
        IMongoCollection<Entities.Product> Products { get; set; }
    }
}