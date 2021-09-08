using System.Net;
using System.Threading.Tasks;
using ECommerce.Basket.API.Entities;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Basket.API.Repositories.Abstractions;

namespace ECommerce.Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("{email}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string email)
        {
            var basket = await _basketRepository.GetBasket(email);
            if (basket==null)
            {
                return Ok(new ShoppingCart(email));
            }

            return Ok(basket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart shoppingCart)
        {
            return Ok(await _basketRepository.UpdateBasket(shoppingCart));
        }

        [HttpDelete("{email}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string email)
        {
            await _basketRepository.DeleteBasket(email);
            return Ok();
        }
    }
}
