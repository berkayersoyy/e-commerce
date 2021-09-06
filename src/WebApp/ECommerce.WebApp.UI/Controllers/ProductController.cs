using System.Threading.Tasks;
using ECommerce.WebApp.UI.Clients;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApp.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductClient _productClient;

        public ProductController(ProductClient productClient)
        {
            _productClient = productClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productList = await _productClient.GetProducts();
            if (productList.IsSuccess)
            {
                return View(productList.Data);
            }
            return View();
        }
    }
}
