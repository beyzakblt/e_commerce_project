using System.Diagnostics;
using e_commerce_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        // 🔴 DbContext inject edildi
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
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

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Kullanıcılars
                .FirstOrDefault(x => x.Users == email && x.Pass == password);

            if (user != null)
            {
                // Giriş yapan kullanıcı
                HttpContext.Session.SetString("UserName", user.Users);

                // Eğer admin ayrımı yapacaksan
                if (user.Users == "admin@gmail.com")
                {
                    HttpContext.Session.SetString("IsAdmin", "true");
                }
                else
                {
                    HttpContext.Session.SetString("IsAdmin", "false");
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Email veya şifre hatalı!";
            return View();
        }

    }
}
