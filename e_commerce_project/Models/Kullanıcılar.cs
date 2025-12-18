using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_project.Models;

[Table("Kullanıcılar")]
public partial class Kullanıcılar
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("users")]
    [StringLength(50)]
    public string? Users { get; set; }

    [Column("pass")]
    [StringLength(50)]
    public string? Pass { get; set; }
}
