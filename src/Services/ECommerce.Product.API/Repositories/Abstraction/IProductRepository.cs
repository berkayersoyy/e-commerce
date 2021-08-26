using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Product.API.Repositories.Abstraction
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entities.Product>> GetProducts();
        Task<Entities.Product> GetProduct(string id);
        Task<IEnumerable<Entities.Product>> GetProductsByName(string name);
        Task<IEnumerable<Entities.Product>> GetProductsByCategory(string categoryName);

        Task Create(Entities.Product product);
        Task<bool> Update(Entities.Product product);
        Task<bool> Delete(string id);
    }
}