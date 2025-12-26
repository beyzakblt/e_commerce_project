using e_commerce_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_project.Controllers
{
    public class YoneticiController : Controller
    {
        private readonly AppDbContext _context;

        // ✅ CONTEXT INJECTION (ŞART)
        public YoneticiController(AppDbContext context)
        {
            _context = context;
        }

        // LİSTE
        public IActionResult Index()
        {
            var liste = _context.Yoneticis.ToList();
            return View(liste);
        }

        // EKLE (GET)
        public IActionResult Ekle()
        {
            return View();
        }

        // EKLE (POST)
        [HttpPost]
        public IActionResult Ekle(string users, string pass, int statu, int durum)
        {
            var yonetici = new Yonetici
            {
                Users = users,
                Pass = pass,
                Statu = statu,
                Durum = durum
            };

            _context.Yoneticis.Add(yonetici);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GÜNCELLE (GET)
        public IActionResult Guncelle(int id)
        {
            var data = _context.Yoneticis.Find(id);
            return View(data);
        }

        // GÜNCELLE (POST)
        [HttpPost]
        public IActionResult Guncelle(int id, string users, int statu, int durum)
        {
            var data = _context.Yoneticis.Find(id);

            data.Users = users;
            data.Statu = statu;
            data.Durum = durum;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // SİL
        public IActionResult Sil(int id)
        {
            var data = _context.Yoneticis.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Yoneticis.Remove(data);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
