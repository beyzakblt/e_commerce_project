using System;
using System.Collections.Generic;

namespace e_commerce_project.Models;

public partial class IletisimDurumLog
{
    public int Id { get; set; }

    public int IletisimId { get; set; }

    public int AdminId { get; set; }

    public bool Okundu { get; set; }

    public DateTime Tarih { get; set; }
}
