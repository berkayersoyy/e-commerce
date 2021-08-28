using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApp.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
