using System.Threading.Tasks;
using ECommerce.Basket.API.Entities;

namespace ECommerce.Basket.API.Repositories.Abstractions
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string email);
        Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);
        Task DeleteBasket(string email);
    }
}