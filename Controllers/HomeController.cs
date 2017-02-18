using Microsoft.AspNetCore.Mvc;

namespace signalR.Controller
{
    public class HomeController : Controller
    {
        public HomeController() { }
        public IActionResult Index()
        {
            return View();
        }
    }
}