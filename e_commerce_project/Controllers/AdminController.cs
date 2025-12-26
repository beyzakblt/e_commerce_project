using e_commerce_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_project.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // =====================
        // LOGIN (POST)
        // =====================
        [HttpPost]
        public IActionResult Login(string users, string pass)
        {
            if (string.IsNullOrEmpty(users) || string.IsNullOrEmpty(pass))
            {
                ViewBag.Error = "Kullanıcı adı ve şifre boş olamaz";
                return View();
            }

            // ✅ DOĞRU DbSet
            var kullanici = _context.Kullanıcılars
                .FirstOrDefault(x => x.Users == users && x.Pass == pass);

            if (kullanici == null)
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                return View();
            }

            // ✅ SESSION
            HttpContext.Session.SetInt32("UserId", kullanici.Id);
            HttpContext.Session.SetString("UserName", kullanici.Users);

            return RedirectToAction("Index");
        }

        // =====================
        // ADMIN ANASAYFA
        // =====================
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Yoneticiler()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login");
            }

            var yoneticiler = _context.Yoneticis.ToList();
            return View(yoneticiler);
        }


        // =====================
        // LOGOUT
        // =====================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
