using System.ComponentModel.DataAnnotations;

namespace e_commerce_project.Models
{
    public class Musteri
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }
}