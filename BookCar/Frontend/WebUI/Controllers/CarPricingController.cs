using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Options";
            ViewBag.v2 = "Pricing Options";
            return View();
        }
    }
}
