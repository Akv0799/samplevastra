using Microsoft.AspNetCore.Mvc;

namespace VastrafySetup.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("test");
            return View();
        }
    }
}
