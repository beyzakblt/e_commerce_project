using e_commerce_project.Models;
using e_commerce_project.Models.OzelModel;
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

        // =====================
        // LOGIN (GET)
        // =====================
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

            var kullanici = _context.Yoneticis
                .FirstOrDefault(x => x.Users == users && x.Pass == pass);

            if (kullanici == null)
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                return View();
            }

            // ✅ SESSION
            HttpContext.Session.SetInt32("AdminId", kullanici.Id);
            HttpContext.Session.SetInt32("Statu", kullanici.Statu);
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

            MenuVeri model = new MenuVeri
            {
                KullaniciSayisi = _context.Kullanıcılars.Count(),

                // 🔥 SADECE OKUNMAMIŞ MESAJLAR
                MesajSayisi = _context.Iletisims.Count(x => x.Okundu == false)
            };

            return View(model);
        }

        // =====================
        // YÖNETİCİLER
        // =====================
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
        // KULLANICILAR
        // =====================
        public IActionResult Kullanicilar()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login");
            }

            var kullanicilar = _context.Kullanıcılars.ToList();
            return View(kullanicilar);
        }

        // =====================
        // İLETİŞİM MESAJLARI
        // =====================
        public IActionResult IletisimMesajlari()
        {
            var mesajlar = _context.Iletisims
                                   .OrderByDescending(x => x.Tarih)
                                   .ToList();
            return View(mesajlar);
        }

        // =====================
        // OKUNDU DURUMU
        // =====================
        [HttpPost]
        public IActionResult OkunduDegistir(int id)
        {
            var mesaj = _context.Iletisims.FirstOrDefault(x => x.Id == id);
            if (mesaj == null)
                return NotFound();

            mesaj.Okundu = !mesaj.Okundu;
            _context.SaveChanges();

            int adminId = HttpContext.Session.GetInt32("UserId") ?? 0;

            IletisimDurumLog log = new IletisimDurumLog
            {
                IletisimId = mesaj.Id,
                AdminId = adminId,
                Okundu = mesaj.Okundu,
                Tarih = DateTime.Now
            };

            _context.IletisimDurumLogs.Add(log);
            _context.SaveChanges();

            return RedirectToAction("IletisimMesajlari");
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
