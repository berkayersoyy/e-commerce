using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApp.UI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
