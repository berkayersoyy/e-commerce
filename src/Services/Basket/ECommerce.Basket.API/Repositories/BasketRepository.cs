using System;
using System.Threading.Tasks;
using ECommerce.Basket.API.Entities;
using ECommerce.Basket.API.Repositories.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ECommerce.Basket.API.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<ShoppingCart> GetBasket(string email)
        {
            var basket = await _redisCache.GetStringAsync(email);
            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            await _redisCache.SetStringAsync(shoppingCart.Email, JsonConvert.SerializeObject(shoppingCart));
            return await GetBasket(shoppingCart.Email);
        }

        public async Task DeleteBasket(string email)
        {
            await _redisCache.RemoveAsync(email);
        }
    }
}