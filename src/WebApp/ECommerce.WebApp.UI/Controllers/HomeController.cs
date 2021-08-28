using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApp.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
