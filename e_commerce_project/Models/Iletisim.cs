using System;
using System.Collections.Generic;

namespace e_commerce_project.Models;

public partial class Iletisim
{
    public int Id { get; set; }

    public string? AdSoyad { get; set; }

    public string? Email { get; set; }

    public string? Mesaj { get; set; }

    public DateTime? Tarih { get; set; }

    public bool Okundu { get; set; }
}
