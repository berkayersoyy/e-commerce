using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ECommerce.Product.API.Repositories.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Product>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}",Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Product),(int)HttpStatusCode.OK)]

        public async Task<ActionResult<Entities.Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product==null)
            {
                _logger.LogError($"Product with id: {id}, has not been found in database");
                return NotFound();
            }

            return Ok(product);
        }
        [HttpGet("GetProductsByName")]
        [ProducesResponseType(typeof(IEnumerable<Entities.Product>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Product>>> GetProductsByName(string name)
        {
            var products = await _productRepository.GetProductsByName(name);
            return Ok(products);
        }
        [HttpGet("GetProductsByCategory")]
        [ProducesResponseType(typeof(IEnumerable<Entities.Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Product>>> GetProductsByCategory(string categoryName)
        {
            var products = await _productRepository.GetProductsByCategory(categoryName);
            return Ok(products);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Entities.Product),(int)HttpStatusCode.Created)]
        public async Task<ActionResult<Entities.Product>> CreateProduct([FromBody] Entities.Product product)
        {
            await _productRepository.Create(product);
            return CreatedAtRoute("GetProduct", new {id = product.Id}, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Entities.Product product)
        {
            var result = await _productRepository.Update(product);
            return Ok(result);
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _productRepository.Delete(id);
            return Ok(result);
        }

    }
}
