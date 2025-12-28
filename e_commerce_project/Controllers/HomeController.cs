using e_commerce_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace e_commerce_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context; // ✅ EKLENDİ

        public HomeController(
            ILogger<HomeController> logger,
            AppDbContext context) // ✅ EKLENDİ
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
        [HttpGet]
        public IActionResult Iletisim()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Iletisim(IFormCollection form)
        {
            try
            {
                string adSoyad = form["AdSoyad"];
                string email = form["Email"];
                string mesaj = form["Mesaj"];

                // ✅ VERİTABANI KAYDI
                Iletisim iletisim = new Iletisim
                {
                    AdSoyad = adSoyad,
                    Email = email,
                    Mesaj = mesaj,
                    Tarih = DateTime.Now
                };

                _context.Iletisims.Add(iletisim);
                _context.SaveChanges();

                // ✅ MAİL AYARLARI
                string senderEmail = "beyzakblt@gmail.com";
                string appPassword = "qvzy aigv lbqh sulc";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, "Web İletişim Formu");
                mail.To.Add(email); // 📩 formu dolduran kişiye gider
                mail.Subject = "📩 İletişim Formunuz Alındı";
                mail.IsBodyHtml = true;

                mail.Body = $@"
            <h2>Mesajınız Alındı</h2>
            <p><strong>Ad Soyad:</strong> {adSoyad}</p>
            <p><strong>Gönderdiğiniz Mesaj:</strong></p>
            <p>{mesaj}</p>
            <hr/>
            <small>En kısa sürede sizinle iletişime geçeceğiz.</small>
        ";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                ViewBag.Success = "Mesajınız başarıyla gönderildi ve kaydedildi.";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Bir hata oluştu: " + ex.Message;
            }

            return View();
        }


    }
}
