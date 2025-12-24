using e_commerce_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Urunlerimiz()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }
    }
}
