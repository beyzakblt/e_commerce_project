using System;
using System.Collections.Generic;

namespace e_commerce_project.Models;

public partial class Yonetici
{
    public int Id { get; set; }

    public string Users { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public bool Statu { get; set; }

    public bool Durum { get; set; }
}
